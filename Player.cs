namespace JogoDaMemória
{
    internal class Player
    {

        //Atributos
        private string _name;
        private int _score;

        //Métodos
        public Player(string name)
        {
            Name = name;
            _score = 0;
        }

        //Propriedade
        public string Name
        {
            //receber o valor atibuído à propriedade(value).
            set
            {
                if (value.Length >= 3)//tamanho da atribuição, quantidade de caracteres para que não fique vazio.
                    _name = value;

            }

            //retorna o valor atribuído anteriormente caso seja "chamado".
            get { return _name; }
        }
        public int Score
        {
            set
            {
                if (value > 0)
                    _score = value;
            }

            get
            {
                return _score;
            }
        }
        public override string ToString()
        {
            return "Nome: " + Name +
                "\nPontução: " + Score;
        }
    }
}
