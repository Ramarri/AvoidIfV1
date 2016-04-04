using System.Collections.Generic;
using System;

namespace AntiSwitch
{
    public class Controller
    {
        readonly Smistatore _smistatore;

        public Controller(Smistatore smistatore)
        {
            _smistatore = smistatore;
        }

        public string MetodoA(string scheme, int param1, int param2)
        {
            return _smistatore.Resolve(scheme).MetodoA(param1, param2);
        }

        public string MetodoB(string scheme, int param1)
        {
            return _smistatore.Resolve(scheme).MetodoB(param1);
        }

        public string MetodoC(string scheme, string param1, string param2)
        {
            return _smistatore.Resolve(scheme).MetodoC(param1, param2);
        }
    }

    public interface IDomainLogic
    {
        bool Handles(string scheme);
        string Scheme { get; }

        string MetodoA(int param1, int param2);
        string MetodoB(int param1);
        string MetodoC(string param1, string param2);
    }

    public class DomainLogicUomo
    {
        string Scheme { get { return "u";} }
        bool Handles(string scheme)
        {
            return scheme == "u" || 
                   scheme == "uomo" || 
                   DateTime.Now.Month == 11 ; // || qualsiasi altra logica
                                              //    eventualmente usando dipendenze esterne
        }
        public DomainLogicUomo(IDipendenzaA dipendenzaA, IDipendenzaB dipendenzaB) { }
    }

    public interface IDipendenzaA
    {
        
    }

    public interface IDipendenzaB
    {

    }

    public class Smistatore
    {
        readonly Dictionary<string, IDomainLogic> _strategies;

        public Smistatore(IDomainLogic uomo, IDomainLogic donna, IDomainLogic bambino)
        {
            _strategies = new Dictionary<string, IDomainLogic>{
                {"u", uomo},
                {"d", donna},
                {"b", bambino}
            };
        }

        public IDomainLogic Resolve(string scheme)
        {
            return _strategies[scheme];
        }
    }

    public class AutoSmistatore
    {
        readonly Dictionary<string, IDomainLogic> _strategies;

        public AutoSmistatore(List<IDomainLogic> strategies)
        {
            _strategies = new Dictionary<string, IDomainLogic>();
            foreach(var strategy in strategies)
            {
                _strategies.Add(strategy.Scheme, strategy);
            }
        }

        public IDomainLogic Resolve(string scheme)
        {
            return _strategies[scheme];
        }
    }

    public class ChainOfResponsibility
    {
        private readonly IEnumerable<IDomainLogic> _strategies;

        public ChainOfResponsibility(List<IDomainLogic> strategies)
        {
            _strategies = strategies;
        }

        public IDomainLogic Resolve(string scheme)
        {
            foreach (var strategy in _strategies)
            {
                if (strategy.Handles(scheme))
                    return strategy;
            }

            throw new MissingHandlerException(string.Format("{0} scheme has no handler", scheme));
        }
    }

    public class MissingHandlerException : Exception
    {
        public MissingHandlerException(Exception ex)
            : base(ex.Message, ex)
        { }

        public MissingHandlerException(string message)
            : base(message)
        { }
    }
}