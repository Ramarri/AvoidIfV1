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
        string MetodoA(int param1, int param2);
        string MetodoB(int param1);
        string MetodoC(string param1, string param2);
    }

    public class DomainLogicUomo
    {
        public DomainLogicUomo(IDipendenzaA dipendenzaA, IDipendenzaB dipendenzaB)
        {
            
        }
    }

    public interface IDipendenzaA
    {
        
    }

    public interface IDipendenzaB
    {

    }

    public class Smistatore
    {
        readonly IDomainLogic _uomo;
        readonly IDomainLogic _donna;
        readonly IDomainLogic _bambino;

        public Smistatore(IDomainLogic uomo, IDomainLogic donna, IDomainLogic bambino)
        {
            _uomo = uomo;
            _donna = donna;
            _bambino = bambino;
        }

        public IDomainLogic Resolve(string scheme)
        {
            switch(scheme)
            {
                case "u":
                    return _uomo;
                    break;
                case "d":
                    return _donna;
                    break;
                case "b":
                    return _bambini;
                    break;
            }
        }
    }
}

