using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidIfV1
{
    public class ActionDispatcher
    {
        private List<Tuple<string, Action, IBaseAction>> Actions = new List<Tuple<string, Action, IBaseAction>>
        {
            new Tuple<string, Action, IBaseAction> ("1", Action.Insert, new ActionOneInsert()),
            new Tuple<string, Action, IBaseAction> ("1", Action.Delete, new ActionOneDelete()),
            new Tuple<string, Action, IBaseAction> ("2", Action.Insert, new ActionTwoInsert()),
            new Tuple<string, Action, IBaseAction> ("2", Action.Delete, new ActionTwoDelete())
        };

        public IBaseAction GetAction(string action, Action method)
        {
            return Actions.Single(a => a.Item1 == action && a.Item2 == method).Item3;
        }
    }

    public enum Action
    {
        Insert,
        Delete
    }
}
