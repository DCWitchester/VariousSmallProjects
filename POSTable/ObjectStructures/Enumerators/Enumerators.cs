using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTable.ObjectStructures.Enumerators
{
    public class Enumerators
    {
        public enum Status
        {
            /// <summary>
            /// the default value
            /// </summary>
            none = 0,
            /// <summary>
            /// the table is open (has no active sale) 
            /// <para/>
            /// white color code:
            /// </summary>
            open = 1,
            /// <summary>
            /// the table is used by another waiter
            /// <para/>
            /// red color code:
            /// </summary>
            inUse = 2,
            /// <summary>
            /// the table is used by a client
            /// <para/>
            /// orange color code:
            /// </summary>
            inUseByClient = 3,
            /// <summary>
            /// the table has an active order that the cook has yet to accept
            /// <para/>
            /// blue color code:
            /// </summary>
            activeOrder = 4,
            /// <summary>
            /// the cook has accepted the order and is being prepared
            /// <para/>
            /// yellow color code:
            /// </summary>
            beingCooked = 5,
            /// <summary>
            /// the order is finished and can be picked up by the waiter
            /// <para/>
            /// green color code:
            /// </summary>
            isFinished = 6
        }
        
        /// <summary>
        /// the pageState for the WaiterMenu Page
        /// </summary>
        public enum PageState
        {
            /// <summary>
            /// the page was initially called
            /// </summary>
            none = 0,
            /// <summary>
            /// the page is waiting for the waiter to login
            /// </summary>
            waitingForLogin = 1,
            /// <summary>
            /// the table menu is being shown
            /// </summary>
            tableMenu,
            /// <summary>
            /// the item menu is being shown
            /// </summary>
            itemMenu,
            /// <summary>
            /// the command validation is being shown
            /// </summary>
            validateCommand
        }

        /// <summary>
        /// the main enum is used for setting the quantity events: adding or subtracting one
        /// </summary>
        public enum QuantityEvents
        {
            add = 0,
            substract = 1
        }
    }
}
