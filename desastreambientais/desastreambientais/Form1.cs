﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desastreambientais
{
    public partial class Form1 : Form
    {
        private DAL _banco = new DAL();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void rsbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO funcionario";
                sql += "(id, nome) VALUES (NULL,";
                sql += textBox1.Text + ",";

                _banco.Inserir(sql);
                txtnome.Text = "";


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
    }

}
