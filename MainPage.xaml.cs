//using Xamarin.Google.Crypto.Tink.Shaded.Protobuf;

namespace AppCalculadora;

public partial class MainPage : ContentPage
{

    private double num1, num2;
    private string operacion;

    public MainPage() {
        InitializeComponent();
    }

    //Este método es para limpiar el lbl
    public void Limpiar(object sender, EventArgs e) {
        lblNumeros.Text = "0";
    }

    //Este método es para el btn x²
    public void Elevar(object sender, EventArgs e) {

        Button btn = (Button)sender;
        string btnPresionado = btn.Text;

        //Acá valida si hay alguno de estos datos en el lbl o si el lbl está vacío e intenta elevar a la 2
        if (lblNumeros.Text == "." || lblNumeros.Text == "+" || lblNumeros.Text == "-" || lblNumeros.Text == "x" || lblNumeros.Text == "÷" || lblNumeros.Text == string.Empty)
        {
            lblNumeros.Text = "ERROR";
        }
        else {
            num1 = double.Parse(lblNumeros.Text);

            Operaciones operaciones = new Operaciones();
            lblNumeros.Text = operaciones.ElevarNumero(num1).ToString();
        }
    }

    //Este método es para sacar la raíz cuadrada de un solo número
    public void Raiz (object sender, EventArgs e) {
        Button btn = (Button)sender;
        string btnPresionado = btn.Text;

        if (lblNumeros.Text == "." || lblNumeros.Text == "+" || lblNumeros.Text == "-" || lblNumeros.Text == "x" || lblNumeros.Text == "÷" || lblNumeros.Text == string.Empty)
        {
            lblNumeros.Text = "ERROR";

        } else if (lblNumeros.Text == "ERROR") {
            lblNumeros.Text = "0";
        } else {
            double num = double.Parse(lblNumeros.Text);
            double resultado = Math.Sqrt(num);
            lblNumeros.Text = resultado.ToString();
        }

    }

    //Este método me borra el último número ingresado en el lbl
    public void Borrar(Object sender, EventArgs e) {

        if (lblNumeros.Text.Length > 1) {
            lblNumeros.Text = lblNumeros.Text.Substring(0, lblNumeros.Text.Length - 1);
        }
        else if (lblNumeros.Text == "+" || lblNumeros.Text == "-" || lblNumeros.Text == "x" || lblNumeros.Text == "÷")
        {
            operacion = "";
            lblNumeros.Text = "0";
        }
        else {
            lblNumeros.Text = "0";
        }
    }

    //Este método es para seleccionar los números
    public void SeleccionDeNumeros(object sender, EventArgs e)
    {

        Button btn = (Button)sender;
        string btnPresionado = btn.Text;

        if (lblNumeros.Text == "0" || lblNumeros.Text == "+" || lblNumeros.Text == "-" || lblNumeros.Text == "x" || lblNumeros.Text == "÷")
        {
            lblNumeros.Text = btnPresionado;
        }
        else if (lblNumeros.Text == "ERROR") //Acá valida si la palabra error está en el lbl que la borre y contunee
        {
            lblNumeros.Text = btnPresionado;
        } else
        {
            lblNumeros.Text += btnPresionado;
        }
    }

	//Este método es para seleccionar la operación deseada
    public void SeleccionDeOperacion (object sender, EventArgs e)	{

        Button btn = (Button)sender;
        string btnPresionado = btn.Text;

        //Acá valido si hay un punto sin números y eligo tocar una operación me diga error
        if (lblNumeros.Text == ".") {
            lblNumeros.Text = "ERROR";
        } else if (lblNumeros.Text == "ERROR") { //Acá valido si la palabra error está en el lbl que me la borre y ponga un 0
            lblNumeros.Text = "0";
        } else if (lblNumeros.Text == "+" || lblNumeros.Text == "x" || lblNumeros.Text == "-" || lblNumeros.Text == "÷") {
            lblNumeros.Text = "ERROR";
        } else {
            num1 = double.Parse(lblNumeros.Text);
            lblNumeros.Text = btnPresionado;
            operacion = btn.Text;
        }
		
    }

	//Este método únicamente me muestra el resultado, se llama al botón de igual =
	public void Resultado (object sender, EventArgs e) {

        //Acá valida que si hay una operación o punto y presiona igual me diga error
        if (lblNumeros.Text == "." || lblNumeros.Text == "+" || lblNumeros.Text == "-" || lblNumeros.Text == "x" || lblNumeros.Text == "÷") {
            lblNumeros.Text = "ERROR";
        } else if (lblNumeros.Text == "ERROR") {
            lblNumeros.Text = "0";
        } else if (lblNumeros.Text.Contains("..")) {
            lblNumeros.Text = "ERROR";
        } else {
            Operaciones operaciones = new Operaciones();
            var resultado = operaciones.HacerOperacion(num1, num2, operacion, lblNumeros.Text);
            lblNumeros.Text = resultado.ToString();
        }
   
	}

}

