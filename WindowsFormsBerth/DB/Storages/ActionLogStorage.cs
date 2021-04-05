using System;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsBerth.DB.Models;
using WindowsFormsTransport.DB.Models;
using WindowsFormsTransport.DB.ViewModels;

namespace WindowsFormsTransport.DB.Storages
{
    class ActionLogStorage
    {
        public List<ActionLog> GetFilteredList(DateTime from, DateTime to, int berthId)
        {
            using (var context = new TransportDatabase())
            {
                return context.ActionLogs
                .Where(rec => (rec.ActionTime.CompareTo(from) > 0) &&
                              (rec.ActionTime.CompareTo(to) < 0) && 
                              rec.BerthId == berthId)
                .Select(rec => new ActionLog
                {
                    Id = rec.Id,
                    BerthId = rec.BerthId,
                    ActionType = rec.ActionType,
                    ActionDescription = rec.ActionDescription,
                    ActionTime = rec.ActionTime
                })
                .ToList();
            }
        }

        public void InsertAction(ActionLog action)
        {
            using (TransportDatabase context = new TransportDatabase())
            {
                context.ActionLogs.Add(action);
                context.SaveChanges();
            }
            return;
        }

        public static void InsertNewAction(int? berthId, string actionDescription, int actionType)
        {
            string actionTypeName = "";
            switch (actionType)
            {
                case (int)ActionTypeEnum.AddShip:
                    actionTypeName = "AddShip";
                    break;
                case (int)ActionTypeEnum.RemoveShip:
                    actionTypeName = "RemoveShip";
                    break;
                case (int)ActionTypeEnum.AddBerth:
                    actionTypeName = "AddBerth";
                    break;
                case (int)ActionTypeEnum.RemoveBerth:
                    actionTypeName = "RemoveBerth";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Недопустимое значение для действия");
            }
            
            DateTime now = DateTime.Now;
            ActionLog action = new ActionLog { 
                BerthId = berthId, 
                ActionTime = DateTime.Now, 
                ActionDescription = actionDescription, 
                ActionType = actionTypeName};

            using (TransportDatabase context = new TransportDatabase())
            {
                context.ActionLogs.Add(action);
                context.SaveChanges();
            }
            return;
        }

        public static void InsertNewAction(string berthName, string actionDescription, int actionType)
        {
            string actionTypeName = "";
            switch (actionType)
            {
                case (int)ActionTypeEnum.AddShip:
                    actionTypeName = "AddShip";
                    break;
                case (int)ActionTypeEnum.RemoveShip:
                    actionTypeName = "RemoveShip";
                    break;
                case (int)ActionTypeEnum.AddBerth:
                    actionTypeName = "AddBerth";
                    break;
                case (int)ActionTypeEnum.RemoveBerth:
                    actionTypeName = "RemoveBerth";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Недопустимое значение для действия");
            }

            BerthViewModel berth = BerthStorage.GetElement(berthName);
            ActionLog action = new ActionLog
            {
                BerthId = berth.Id,
                ActionTime = DateTime.Now,
                ActionDescription = actionDescription,
                ActionType = actionTypeName
            };

            using (TransportDatabase context = new TransportDatabase())
            {
                context.ActionLogs.Add(action);
                context.SaveChanges();
            }
            return;
        }
    }
}
