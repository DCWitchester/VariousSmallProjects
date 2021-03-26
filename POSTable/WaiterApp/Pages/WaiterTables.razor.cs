﻿using Microsoft.AspNetCore.Components;
using POSTable.ObjectStructures.Enumerators;
using POSTable.WaiterApp.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSTable.WaiterApp.Pages
{
    public partial class WaiterTables
    {
        #region Properties
        
        #endregion

        [CascadingParameter]
        WaiterController WaiterController { get; set; }

        protected override Task OnInitializedAsync()
        {
            GetTables();
            StartTimer();
            return base.OnInitializedAsync();
        }

        #region Functionality
        /// <summary>
        /// this function will retrieve
        /// </summary>
        protected async void GetTables()
        {
            String xmlDocument = await httpClient.GetStringAsync(WebMethods.GetTables);
            //and a new serializer over the answer object
            XmlSerializer xmlSerializer = new(typeof(XmlClasses.Tables));
            //then using a text reader
            using TextReader reader = new StringReader(xmlDocument);
            //we deserialize the object
            WaiterController.Tables = ((XmlClasses.Tables)xmlSerializer.Deserialize(reader)).tables
                                        .Select(element => new ObjectStructures.Table
                                        (
                                            id:element.TableID,
                                            status: GetStatusForWaiter(element.Status, element.WaiterID, element.WaiterCode),
                                            waiter: new ObjectStructures.Waiter
                                            (
                                                id:element.WaiterID,
                                                waiterCode: element.WaiterCode,
                                                waiterName: element.WaiterName
                                                )
                                            )).ToList();
        }

        /// <summary>
        /// this function will get the status for a given table dependent on the user
        /// </summary>
        /// <param name="status">the given status</param>
        /// <param name="waiterID"> the given waiter id</param>
        /// <returns>the table display status</returns>
        protected Enumerators.Status GetStatusForWaiter(Int32 status, Int32 waiterID, String waiterCode)
        {
            if (WaiterController.Waiter.ID == waiterID) return (Enumerators.Status) status;
            if (waiterID != -1)
                if (waiterCode.ToUpper().Trim() == "".PadRight(10, 'X').ToUpper().Trim()) return Enumerators.Status.inUseByClient;
                else return Enumerators.Status.inUse;
            return Enumerators.Status.open;
        }
        #endregion

        #region Timer Events
        /// <summary>
        /// this function will start the timer bound to the page
        /// </summary>
        protected void StartTimer()
        {
            tableTimer.OnElapsed += GetTables;
            tableTimer.SetTimer(Settings.PublicSettings.TableRefreshTimer);
        }
        /// <summary>
        /// this function will stop the timer bound to the page
        /// </summary>
        protected void StopTimer()
        {
            tableTimer.StopTimer();
        }
        #endregion
    }
}