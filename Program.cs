Jugador jug1 = new Jugador(7, "Cristiano", Posicion.Delantero);
Jugador jug2 = new Jugador(10, "Messi", Posicion.Delantero);
Jugador jug3 = new Jugador(9, "Nicco Williams", Posicion.Delantero);

Equipo equipo = new Equipo (1854,"Real Murcia", "Murcia", new List<Jugador>());
equipo.AñadirJugadores( jug1, jug2, jug3);

Console.WriteLine(equipo.ToString());

public enum Posicion
{
    Delantero,
    Centro,
    Defensa,
    Portero
}
public class Jugador
{
    public int Dorsal { get; }
    public string Nombre { get; private set; }
    public Posicion Posicion { get; private set; }

    public Jugador (int dorsal, string nombre, Posicion posicion)
    {
        Dorsal = dorsal;
        Nombre = nombre;
        Posicion = posicion;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, Dorsal: {Dorsal}, Posición: {Posicion}";
    }
        
}

public class Equipo
{


    public string Nombre { get; init; }
    public string Ciudad { get; set; }
    public List<Jugador> Jugadores { get; set; }
    private int _anioFundacion;

    public Equipo(int anioFundacion, string nombre, string ciudad, List<Jugador> jugadores)
    {
        _anioFundacion = anioFundacion;
        Nombre = nombre;
        Ciudad = ciudad;
        Jugadores = jugadores;
    }

    public int AnioFundacion 
    {
        get => _anioFundacion;
        set 
        {
            if (value < 1800)
            {
                throw new ArgumentException("El valor debe ser mayor a 1800");
            }
            _anioFundacion = value;
        } 
    }

    public void AñadirJugadores(Jugador a) => Jugadores.Add(a);

    public void AñadirJugadores(Jugador a, Jugador b)
    {
        Jugadores.Add(a);
        Jugadores.Add(b);
    }

    public void AñadirJugadores (params Jugador[] a)
    {
        for(int i= 0; i < a.Length; i++)
        {
            Jugadores.Add(a[i]);
        }
    }

    public string ListarJugadores()
    {
        string s = "";
        foreach (var jugador in Jugadores)
        {
            s = s + "\n  " + jugador;
        }

        return s;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, Ciudad: {Ciudad}, Año de fundación: {_anioFundacion}, \nJugadores en el equipo: {ListarJugadores()}";
    }
}