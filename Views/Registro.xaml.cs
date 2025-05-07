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
        if (pickerVA.SelectedIndex == -1)
        {
            DisplayAlert("Error", "Seleccione un Voltiamperio (VA) antes de calcular.", "OK");
            return;
        }

        const double costoUPS = 300;
        double montoInicial = costoUPS * 0.15;
        double restante = costoUPS - montoInicial;
        double cuotaBase = restante / 3;
        double cuotaConInteres = cuotaBase + (costoUPS * 0.05);

        if (cuotaConInteres > 0)
        {
            entryPagoMensual.Text = cuotaConInteres.ToString("F2");
        }
        else
        {
            DisplayAlert("Error", "Error en el cálculo. Verifique los datos.", "OK");
        }
    }

    private async void OnResumenClicked(object sender, EventArgs e)
    {
        
        if (string.IsNullOrWhiteSpace(entryNombre.Text) ||
            string.IsNullOrWhiteSpace(entryApellido.Text) ||
            pickerVA.SelectedIndex == -1 ||
            pickerCiudad.SelectedIndex == -1 ||
            string.IsNullOrWhiteSpace(entryPagoMensual.Text))
        {
            await DisplayAlert("Faltan datos", "Complete todos los campos antes de continuar", "OK");
            return;
        }

        string nombre = entryNombre.Text;
        string apellido = entryApellido.Text;
        string va = pickerVA.SelectedItem.ToString();
        DateTime fecha = dateFecha.Date;
        string ciudad = pickerCiudad.SelectedItem.ToString();
        double montoInicial = double.Parse(entryMontoInicial.Text);
        double cuotaMensual = double.Parse(entryPagoMensual.Text);
        double pagoTotal = montoInicial + (cuotaMensual * 3);

        await Navigation.PushAsync(new Resumen(
            usuario, nombre, apellido, va,
            fecha, ciudad, montoInicial, cuotaMensual, pagoTotal
        ));
    }
}