Jugador jug1 = new Jugador(7, "Cristiano", Posicion.Delantero);
Jugador jug2 = new Jugador(10, "Messi", Posicion.Delantero);
Jugador jug3 = new Jugador(9, "Nicco Williams", Posicion.Delantero);

Equipo equipo = new Equipo (1854,"Real Murcia", "Murcia", new List<Jugador>());
equipo.JugadorNuevo += EquipoJugadorNuevo;
equipo.AñadirJugadores( jug1, jug2, jug3);

equipo.JugadorDeBaja += EquipoJugadorDeBaja;

void EquipoJugadorDeBaja(object? sender, JugadorDeBajaEventArgs e)
{
    Console.WriteLine($"Se ha dado de baja el jugador con nombre: {e.Jugador.Nombre}");
}

equipo.BuscarjugadorYDarDeBaja(10);

void EquipoJugadorNuevo(object? sender, EventArgs e)
{
    Console.WriteLine("NUEVO JUGADOR");
}

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
    public event EventHandler? JugadorNuevo;
    public event EventHandler<JugadorDeBajaEventArgs>? JugadorDeBaja;

    public Equipo(int anioFundacion, string nombre, string ciudad, List<Jugador> jugadores)
    {
        _anioFundacion = anioFundacion;
        Nombre = nombre;
        Ciudad = ciudad;
        Jugadores = jugadores;
    }

    protected virtual void OnJugadorNuevo()
    {
        JugadorNuevo?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnJugadorDebaja(Jugador jugador)
    {
        JugadorDeBaja?.Invoke(this, new JugadorDeBajaEventArgs(jugador));
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
        OnJugadorNuevo();
        Jugadores.Add(b);
        OnJugadorNuevo();
    }

    public void AñadirJugadores (params Jugador[] a)
    {
        for(int i= 0; i < a.Length; i++)
        {
            Jugadores.Add(a[i]);
            OnJugadorNuevo();
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

    public void BuscarjugadorYDarDeBaja(int dorsal)
    {
        foreach (var jugador in Jugadores)
        {
            if (jugador.Dorsal == dorsal)
            {
                Jugadores.Remove(jugador);
                OnJugadorDebaja(jugador);
                // Console.WriteLine($"Se ha eliminado el jugador con dorsal {dorsal}.");
                return;
            }
        }
    }
    
}

public class JugadorDeBajaEventArgs : EventArgs
{
    public Jugador Jugador { get; }

    public JugadorDeBajaEventArgs(Jugador jugador)
    {
        Jugador = jugador;
    }
}