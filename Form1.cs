using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        bool _turno = true;
        int _qtddTurnos = 0;
        int _PontosX = 0;
        int _PontosO = 0;
        int _Empates = 0;
        string _Player1 = "X";
        string _Player2 = "O";
        bool _ModoAlone = true;
        Button[,] _pos = new Button[4, 4];

        public Form1()
        {
            //coloca os button em um array
            _pos[1, 1] = A1;
            _pos[1, 2] = A2;
            _pos[1, 3] = A3;
            _pos[2, 1] = B1;
            _pos[2, 2] = B2;
            _pos[2, 3] = B3;
            _pos[3, 1] = C1;
            _pos[3, 2] = C2;
            _pos[3, 3] = C3;

            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Spaces(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (_turno == true)
            {
                button.Text = "X";
            }
            else
            {
                button.Text = "O";
            }
            button.Enabled = false;
            _qtddTurnos += 1;
            if(_qtddTurnos > 3)
            {
                VerificaVencedor();
            }
            _turno = !_turno;

        }

        private void VerificaVencedor()
        {
            bool _HouveVencedor = false;
            bool _empate = false;

            //Verifi a Horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (A1.Enabled == false))
            {
                _HouveVencedor = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (B1.Enabled == false))
            {
                _HouveVencedor = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (C1.Enabled == false))
            {
                _HouveVencedor = true;
            }

            //Verifica a Vertical
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (A1.Enabled == false))
            {
                _HouveVencedor = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (A2.Enabled == false))
            {
                _HouveVencedor = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (A3.Enabled == false))
            {
                _HouveVencedor = true;
            }

            //Verifica em X
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (A1.Enabled == false))
            {
                _HouveVencedor = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (C1.Enabled == false))
            {
                _HouveVencedor = true;
            }

            //verifica empate
            if (_qtddTurnos == 9)
            {
                _empate = true;
            }

            if ((_HouveVencedor == true) && (_turno == true))
            {
                string Message = (_Player1 + " venceu");
                string caption = "End";

                _PontosX += 1;
                string Puntos = Convert.ToString(_PontosX);
                PX.Text = Puntos;

                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult _result;

                _result = MessageBox.Show(Message, caption, buttons);
                if (_result == System.Windows.Forms.DialogResult.OK)
                {
                    _SoftReset();
                }
            }
            else if ((_HouveVencedor == true) && (_turno == false))
            {
                string Message = (_Player2 + " venceu");
                string caption = "End";

                _PontosO += 1;
                string Puntos = Convert.ToString(_PontosO);
                PO.Text = Puntos;

                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult _result;

                _result = MessageBox.Show(Message, caption, buttons);
                if (_result == System.Windows.Forms.DialogResult.OK)
                {
                    _SoftReset();

                }

            }
            else if (_empate == true)
            {
                string Message = ("Empate");
                string caption = "End";

                _Empates += 1;
                string Puntos = Convert.ToString(_Empates);
                PE.Text = Puntos;

                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult _result;

                _result = MessageBox.Show(Message, caption, buttons);
                if (_result == System.Windows.Forms.DialogResult.OK)
                {
                    _SoftReset();
                }
            }
        }

        //Mostra "Quem joga" nos quadrados.
        private void preview(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (_turno == true)
            {
                button.Text = "X";
            }
            else if (_turno == false)
            {
                button.Text = "O";
            }
        }

        //Volta os quadrado ao normal.
        private void apreview(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Enabled == true)
            {
                button.Text = "";
            }
        }


        //Reseta os quadrados
        private void _SoftReset()
        {
            A1.Text = "";
            A2.Text = "";
            A3.Text = "";
            B1.Text = "";
            B2.Text = "";
            B3.Text = "";
            C1.Text = "";
            C2.Text = "";
            C3.Text = "";

            A1.Enabled = true;
            A2.Enabled = true;
            A3.Enabled = true;
            B1.Enabled = true;
            B2.Enabled = true;
            B3.Enabled = true;
            C1.Enabled = true;
            C2.Enabled = true;
            C3.Enabled = true;
            _qtddTurnos = 0;
            _turno = true;
        }
        //Reseta Tudo
        private void _HardReset()
        {
            A1.Text = "";
            A2.Text = "";
            A3.Text = "";
            B1.Text = "";
            B2.Text = "";
            B3.Text = "";
            C1.Text = "";
            C2.Text = "";
            C3.Text = "";

            A1.Enabled = true;
            A2.Enabled = true;
            A3.Enabled = true;
            B1.Enabled = true;
            B2.Enabled = true;
            B3.Enabled = true;
            C1.Enabled = true;
            C2.Enabled = true;
            C3.Enabled = true;
            _qtddTurnos = 0;
            _Empates = 0;
            _PontosX = 0;
            _PontosO = 0;
            PO.Text = "0";
            PX.Text = "0";
            PE.Text = "0";
            _turno = true;
        }

        //Barra em cima
        private void novoJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _HardReset();
        }

        //Zera a pontuação sem alterar o resto.
        private void ZerarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PO.Text = "0";
            PX.Text = "0";
            PE.Text = "0";
            _Empates = 0;
            _PontosX = 0;
            _PontosO = 0;

        }

        //Encerra a execução do forms
        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        //Mostra quem fez ;)
        private void sobreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Criado Por Marco Anthony ;)");
        }
    }
}

