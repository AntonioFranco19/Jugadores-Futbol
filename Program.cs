var jug1 = new Jugador(7, "Cristiano", Posicion.Delantero);
var jug2 = new Jugador(10, "Messi", Posicion.Delantero);
var jug3 = new Jugador(9, "Nicco Williams", Posicion.Delantero);

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
        return $"Nombre. {Nombre}, Dorsal: {Dorsal}, Posición: {Posicion}";
    }
        
}

public class Equipo
{
    public string Nombre { get; init; }
    public string Ciudad { get; private set; }
    public List<Jugador> Jugadores { get; private set; }

    public int AnioFundacion 
    {
        get => _anioFundacion;
        set 
        {
            if (value < 1800)
            {
                throw new ArgumentException("El valor debe ser mayor a 1800");
            }
            _anio = value;
        } 
    }

    public void AñadirJugadores(Jugador a) => Jugadores.Add(a);

    public void AñadirJugadores(Jugador a, Jugador b)
    {
        Jugadores.Add(a);
        Jugadores.Add(b);
    }

    public void Añadirjugadores (params Jugador[] a)
    {
        for(int i= 0; i<= a.Length; i++)
        {
            Jugadores.Add(a[i]);
        }
    }
}