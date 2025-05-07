namespace jcevallosExame.Views;

public partial class Resumen : ContentPage
{
    public Resumen(string usuario, string nombre, string apellido, string va,
                   DateTime fecha, string ciudad, double montoInicial, double cuotaMensual, double pagoTotal)
    {
        InitializeComponent();

        lblUsuario.Text = usuario;
        lblNombre.Text = nombre;
        lblApellido.Text = apellido;
        lblVA.Text = va;
        lblFecha.Text = fecha.ToString("dd/MM/yyyy"); // Formato bonito de fecha
        lblCiudad.Text = ciudad;
        lblMontoInicial.Text = montoInicial.ToString("F2");
        lblPagoMensual.Text = cuotaMensual.ToString("F2");
        lblPagoTotal.Text = pagoTotal.ToString("F2");
    }

    private async void OnCerrarSesionClicked(object sender, EventArgs e)
    {
        // Volver a la pantalla de login
        await Navigation.PopToRootAsync();
    }
}