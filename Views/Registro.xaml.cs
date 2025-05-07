namespace jcevallosExame.Views;

public partial class Registro : ContentPage
{
    private string usuario;
    private const double costoUPS = 300;

    public Registro(string usuarioConectado)
    {
        InitializeComponent();
        usuario = usuarioConectado;
        lblUsuario.Text = $"Usuario conectado: {usuario}";

        // Al cargar, ponemos automáticamente el monto inicial
        double montoInicial = costoUPS * 0.15;
        entryMontoInicial.Text = montoInicial.ToString("F2");
        entryMontoInicial.IsReadOnly = true;
    }

    private void OnCalcularClicked(object sender, EventArgs e)
    {
        // Calculamos automáticamente
        double montoInicial = costoUPS * 0.15;
        double restante = costoUPS - montoInicial;
        double cuotaBase = restante / 3;
        double cuotaConInteres = cuotaBase + (costoUPS * 0.05); // 5% adicional

        entryPagoMensual.Text = cuotaConInteres.ToString("F2");
    }

    private async void OnResumenClicked(object sender, EventArgs e)
    {
        // Validaciones básicas
        if (string.IsNullOrWhiteSpace(entryNombre.Text) ||
            string.IsNullOrWhiteSpace(entryApellido.Text) ||
            pickerVA.SelectedIndex == -1 ||
            pickerCiudad.SelectedIndex == -1 ||
            string.IsNullOrWhiteSpace(entryPagoMensual.Text))
        {
            await DisplayAlert("Faltan datos", "Complete todos los campos antes de continuar", "OK");
            return;
        }

        // Recolectar datos
        string nombre = entryNombre.Text;
        string apellido = entryApellido.Text;
        string va = pickerVA.SelectedItem.ToString();
        DateTime fecha = dateFecha.Date;
        string ciudad = pickerCiudad.SelectedItem.ToString();
        double montoInicial = double.Parse(entryMontoInicial.Text);
        double cuotaMensual = double.Parse(entryPagoMensual.Text);
        double pagoTotal = montoInicial + (cuotaMensual * 3);

        // Navegar a Resumen
        await Navigation.PushAsync(new Resumen(
            usuario, nombre, apellido, va,
            fecha, ciudad, montoInicial, cuotaMensual, pagoTotal
        ));
    }
}