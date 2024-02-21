using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangLib.IFF;
using PangLib.IFF.Models.Data;
using Pangya_Modern_Editor.Extensions;

namespace Pangya_Modern_Editor.Forms.Editors
{
    public partial class FrmEditorCaddies : Form
    {
        public FrmEditorCaddies()
        {
            Arquivo = "";
            this.bs = new BindingSource();
            InitializeComponent();
        }

        private void AlterarDescontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MyProject.Forms.frmItemMassaDesconto.Show();
        }

        private void Alterou()
        {
            this.Alterado = true;
        }

        private void attControle_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraControle, RuntimeHelpers.GetObjectValue(sender));
        }

        private void attCurva_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraCurva, RuntimeHelpers.GetObjectValue(sender));
        }

        private void attForca_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraForca, RuntimeHelpers.GetObjectValue(sender));
        }

        private void attPrecisao_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraPrecisao, RuntimeHelpers.GetObjectValue(sender));
        }

        private void attSpin_ValueChanged(object sender, EventArgs e)
        {
            this.gerarBarra(this.barraSpin, RuntimeHelpers.GetObjectValue(sender));
        }

        private void FrmEditorCaddies_Closing(object sender, FormClosingEventArgs e)
        {
            if (this.bwGerarSql.IsBusy | this.bwSalvar.IsBusy)
            {
                MessageBox.Show("Existem tarefas ainda em execu\x00e7\x00e3o, \x00e9 necess\x00e1rio aguardar o t\x00e9rmino destas tarefas", "Tarefas pendentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }
        private void FrmEditorCaddies_Load(object sender, EventArgs e)
        {
            if (this.Arquivo != "")
            {
                this.lsItens = new IFFFile<Caddie>();
                this.lsTemp = new IFFFile<Caddie>();
                this.Arquivo = this.diagAbrirArquivo.FileName;
                //  MySettingsProperty.Settings.ArquivoIff = this.Arquivo;
                try
                {
                    this.lsItens = new IFFFile<Caddie>(Arquivo);
                    //this.ls = Util.dividirArquivo((List<string>)Util.lerArquivo(this.Arquivo, ref this.bStart, ref this.qtdItem, 200), 200);
                }
                catch (Exception exception1)
                {
                    MessageBox.Show("Arquivo danificado ou desconhecido", "Erro de leitura", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                    return;
                }
                this.lsTemp = this.lsItens;
                
                int length = 0x19;
                if (Strings.Len(this.Arquivo) > 0x19)
                {
                    this.lbArquivo.Text = "..." + this.Arquivo.Substring(Strings.Len(this.Arquivo) - length, length);
                }
                else
                {
                    this.lbArquivo.Text = this.Arquivo;
                }
                this.ListaItem.DataSource = null;
                this.CarregarGrid(this.lsTemp);
                this.lbIndices.Text = Conversions.ToString(this.qtdItem);
            }
            this.ComboBox1.SelectedIndex = 0;
            this.ComboBox2.SelectedIndex = 0;
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if ((this.diagAbrirArquivo.ShowDialog() == DialogResult.OK) && (this.diagAbrirArquivo.FileName != ""))
            {
                this.lsItens = new IFFFile<Caddie>();
                this.lsTemp = new IFFFile<Caddie>();
                this.Arquivo = this.diagAbrirArquivo.FileName;
                //  MySettingsProperty.Settings.ArquivoIff = this.Arquivo;
                try
                {
                    this.lsItens = new IFFFile<Caddie>(Arquivo);
                    //this.ls = Util.dividirArquivo((List<string>)Util.lerArquivo(this.Arquivo, ref this.bStart, ref this.qtdItem, 200), 200);
                }
                catch (Exception exception1)
                {
                    MessageBox.Show("Arquivo danificado ou desconhecido", "Erro de leitura", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    
                    return;
                }
                this.lsTemp = this.lsItens;
                this.nomeArquivo();
                this.ListaItem.DataSource = null;
                this.CarregarGrid(this.lsTemp);
                this.lbIndices.Text = Conversions.ToString(this.qtdItem);
            }
        }


        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja clonar o item selecionado?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Caddie item = new Caddie();
                this.lastRow = this.ListaItem.SelectedCells[0].RowIndex + 1;
                item = (Caddie)this.lsTemp[Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value)];
                try
                {
                    this.lsTemp.Insert(Conversions.ToInteger(Operators.AddObject(this.ListaItem.SelectedRows[0].Cells[0].Value, 1)), item);
                }
                catch (Exception exception1)
                {
                                   MessageBox.Show("Pangya Modern Editor IFF", exception1.Message);
                    this.lsTemp.Insert(Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value), item);
                    
                }
                this.CarregarGrid(this.lsTemp);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja adicionar um novo item?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Caddie item = new Caddie()
                {
                    Name = "[NOVO ITEM]"
                };
                Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value);
                try
                {
                    this.lsTemp.Insert(this.ListaItem.SelectedCells[0].RowIndex + 1, item);
                }
                catch (Exception exception1)
                {
                                   MessageBox.Show("Pangya Modern Editor IFF", exception1.Message);
                    this.lsTemp.Insert(this.ListaItem.SelectedCells[0].RowIndex, item);
                    
                }
                this.lastRow = this.ListaItem.SelectedCells[0].RowIndex + 1;
                this.CarregarGrid(this.lsTemp);
                try
                {
                    this.ListaItem.FirstDisplayedScrollingRowIndex = this.lastRow;
                    this.ListaItem.Rows[this.lastRow].Selected = true;
                }
                catch (Exception exception3)
                {
                    ProjectData.SetProjectError(exception3);
                    this.ListaItem.FirstDisplayedScrollingRowIndex = this.lastRow - 1;
                    this.ListaItem.Rows[this.lastRow - 1].Selected = true;
                    
                }
            }
        }

        private void btnReabrir_Click(object sender, EventArgs e)
        {
            this.salvarAlteracoes();
            this.pintarLinhas();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (this.ListaItem.SelectedRows.Count <= 1)
            {
                this.lastRow = this.ListaItem.SelectedCells[0].RowIndex - 1;
                if (MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Deseja remover o item: ", this.ListaItem.SelectedRows[0].Cells[1].Value), " ?")), "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int num2 = Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value);
                    this.lsTemp.Remove(this.lsTemp[num2]);
                    this.CarregarGrid(this.lsTemp);
                }
            }
            else
            {
                this.lastRow = this.ListaItem.SelectedRows[0].Index - 1;
                if (MessageBox.Show("Deseja remover os " + Conversions.ToString(this.ListaItem.SelectedRows.Count) + " itens selecionados?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int num3 = this.ListaItem.SelectedRows.Count - 1;
                    int num = 0;
                    while (true)
                    {
                        if (num > num3)
                        {
                            break;
                        }
                        try
                        {
                            this.lsTemp.Remove(this.lsTemp[Conversions.ToInteger(this.ListaItem.SelectedRows[num].Cells[0].Value)]);
                        }
                        catch (Exception exception1)
                        {
                                           MessageBox.Show("Pangya Modern Editor IFF", exception1.Message);
                            
                        }
                        num++;
                    }
                    this.CarregarGrid(this.lsTemp);
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.bs.Filter = "";
            this.ComboBox1.SelectedIndex = 0;
            this.ComboBox2.SelectedIndex = 0;
            this.salvarAlteracoes();
            this.btnSalvar.Enabled = false;
            this.ToolStrip1.Enabled = false;
            this.pbStatus.Style = ProgressBarStyle.Marquee;
            this.bwSalvar.RunWorkerAsync();
        }

        private void btnVerificarTYPEID_Click(object sender, EventArgs e)
        {
            if (this.verificarTYPEID(0))
            {
                MessageBox.Show("Este TYPEID j\x00e1 est\x00e1 em uso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtTypeID.BackColor = Color.LightSalmon;
            }
            else
            {
                MessageBox.Show("TYPEID dispon\x00edvel para uso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtTypeID.BackColor = Color.White;
            }
        }

        private void bwGerarSql_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bW = (BackgroundWorker)sender;
            this.gerarSql(bW);
            if (bW.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwGerarSql_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbStatus.Value = e.ProgressPercentage;
            this.lbStatus.Text = "Gerando arquivo SQL - " + Conversions.ToString(e.ProgressPercentage) + "%";
        }

        private void bwGerarSql_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.pbStatus.Value = 0;
            this.btnSalvar.Enabled = true;
            this.ToolStrip1.Enabled = true;
            this.lbStatus.Text = "parado";
        }

        private void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bW = (BackgroundWorker)sender;
            this.lbStatus.Text = "Salvando...";
            this.salvar(bW);
            if (bW.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void bwSalvar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbStatus.Style = ProgressBarStyle.Marquee;
            this.lbStatus.Text = "Salvando...";
        }

        private void bwSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.pbStatus.Style = ProgressBarStyle.Blocks;
            this.pbStatus.Value = 0;
            this.lbStatus.Text = "parado";
            this.btnSalvar.Enabled = true;
            this.ToolStrip1.Enabled = true;
            this.lbIndices.Text = Conversions.ToString(this.qtdItem);
            this.nomeArquivo();
        }

        public void CarregarGrid(List<Caddie> Lista)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Status", typeof(Image));
            table.Columns.Add("Personagem", typeof(string));
            table.Columns.Add("Status2", typeof(string));
            table.Columns.Add("Tipo", typeof(Image));
            table.Columns.Add("Alterado", typeof(int));

            for (int num3 = 0; num3 < Lista.Count; num3++)
            {
                Caddie oIff = Lista[num3];
                Image statusImage = (oIff.Active == 1) ? Properties.Resources.accept1 : Properties.Resources.delete1;
                Image tipoImage;

                if ((int)oIff.Shop.flag_shop.ShopFlag == 1)
                {
                    tipoImage = Properties.Resources.points;
                }
                else if ((int)(oIff.ShopFlag) == 2)
                {
                    tipoImage = Properties.Resources.Pang;
                }
                else
                {
                    tipoImage = Properties.Resources.eye__minus;
                }

                int num4 = 0;

                try
                {
                    num4 = Conversions.ToInteger(ListaItem["Alterado", num3].Value);
                }
                catch (Exception)
                {
                    num4 = 0;
                    // Handle exception if needed
                }

                table.Rows.Add(new object[] { num3, oIff.Name.Replace("\0", ""), statusImage, 0, oIff.Active, tipoImage, num4 });
            }

            ListaItem.DataSource = null;
            bs = new BindingSource();
            bs.DataSource = table;
            ListaItem.DataMember = table.TableName;
            ListaItem.DataSource = bs;

            lbTotalItens.Text = Conversions.ToString(ListaItem.Rows.Count);

            ListaItem.Columns[0].Width = 0x2d;
            ListaItem.Columns[2].Width = 30;
            ListaItem.Columns[5].Width = 30;

            ListaItem.Columns[0].ValueType = typeof(int);
            ListaItem.Columns[2].HeaderText = "   ";
            ListaItem.Columns[5].HeaderText = "   ";

            for (int i = 0; i < ListaItem.Rows.Count; i++)
            {
                ListaItem.Rows[i].Selected = false;
            }

            ListaItem.Columns[3].Visible = false;
            ListaItem.Columns[4].Visible = false;
            ListaItem.Columns[6].Visible = false;

            filtrar();

            try
            {
                ListaItem.FirstDisplayedScrollingRowIndex = lastRow;
                ListaItem.Rows[lastRow].Selected = true;
            }
            catch (Exception)
            {
                // Handle exception if needed
            }

            pintarLinhas();
        }

        private void carregarImagem(string img, ref PictureBox obj)
        {
            try
            {
                obj.Image = Pangya_Modern_Editor.Properties.Resources.ajax_loader;
            }
            catch (Exception exception1)
            {
                               MessageBox.Show("Pangya Modern Editor IFF", exception1.Message);
                
            }
            try
            {
                obj.ImageLocation = img;
            }
            catch (Exception exception3)
            {
                ProjectData.SetProjectError(exception3);
                obj.Image = Pangya_Modern_Editor.Properties.Resources._error;
                
            }
        }

        private void CarregarItem()
        {
            if (this.ListaItem.SelectedCells[0].RowIndex > -1)
            {
                int num2 = Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value);
                int lvlReq = 0;
                this.txtNome.Text = this.lsTemp[num2].Name;
                this.txtTypeID.Text = Conversions.ToString(this.lsTemp[num2].ID);
                this.ckAtivo.Checked = this.lsTemp[num2].Active > 0;
                this.txtIcone.Text = this.lsTemp[num2].Icon;
                this.txtPreco.Text = Conversions.ToString(this.lsTemp[num2].Price);
                this.txtDesconto.Text = Conversions.ToString(this.lsTemp[num2].DiscountPrice);
                this.attForca.Value = new decimal(this.lsTemp[num2].Power);
                this.attControle.Value = new decimal(this.lsTemp[num2].Control);
                this.attPrecisao.Value = new decimal(this.lsTemp[num2].Impact);
                this.attSpin.Value = new decimal(this.lsTemp[num2].Spin);
                this.attCurva.Value = new decimal(this.lsTemp[num2].Curve);
                this.txtSprite.Text = this.lsTemp[num2].MPet;
                this.txtSalary.Text = Conversions.ToString(this.lsTemp[num2].Salary);
                if (this.lsTemp[num2].ItemLevel <= 0x48)
                {
                    lvlReq = this.lsTemp[num2].ItemLevel;
                    this.rbLevelMin.Checked = true;
                }
                else
                {
                    lvlReq = this.lsTemp[num2].ItemLevel - 0x80;
                    this.rbLevelMax.Checked = true;
                }
                cbTipo.SelectedIndex = lsTemp[num2].GetTypeCash();

                ckNormal.Checked = lsTemp[num2].Shop.flag_shop.IsNormal || lsTemp[num2].Shop.flag_shop.is_saleable;
                ckDesativado.Checked = lsTemp[num2].Shop.flag_shop.IsHide;
                ckNew.Checked = lsTemp[num2].Shop.flag_shop.IsNew;
                ckGift.Checked = lsTemp[num2].Shop.flag_shop.IsGift;
                ckHot.Checked = lsTemp[num2].Shop.flag_shop.IsHot;
                this.cbLevel.SelectedIndex = lvlReq;
                dtInicio.Value = lsTemp[num2].date.Start.Time;
                dtTermino.Value = lsTemp[num2].date.End.Time;
                ckTempoAtivo.Checked = lsTemp[num2].date.Check();
                
            }
            this.Alterado = false;
          
        }

        private void ckDesativado_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDesativado.Checked)
            {
                ckNew.Checked = false;
                ckNormal.Checked = false;
                ckHot.Checked = false;
                ckGift.Checked = false;
            }
        }

        private void ckTempoAtivo_CheckedChanged(object sender, EventArgs e)
        {
            this.gbTempoVenda.Enabled = this.ckTempoAtivo.Checked;
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filtrar();
            this.imgPersonagem.Image = this.ImageList1.Images[this.ComboBox1.SelectedIndex];
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.filtrar();
            this.imgStatus.Image = (this.ComboBox2.SelectedIndex != 0) ? ((this.ComboBox2.SelectedIndex != 1) ? this.ImageList2.Images[2] : this.ImageList2.Images[1]) : this.ImageList2.Images[0];
        }

        public void filtrar()
        {
            try
            {
                int num = 0;
                num = (this.ComboBox2.SelectedIndex != 1) ? 0 : 1;
                if (!(((this.ComboBox1.SelectedIndex > 0) & (this.ComboBox2.SelectedIndex > 0)) & (this.txtPesquisa.Text.Length > 0)))
                {
                    this.bs.Filter = !((this.ComboBox1.SelectedIndex > 0) & (this.txtPesquisa.Text.Length > 0)) ? (!((this.ComboBox2.SelectedIndex > 0) & (this.txtPesquisa.Text.Length > 0)) ? (!((this.ComboBox1.SelectedIndex > 0) & (this.ComboBox2.SelectedIndex > 0)) ? ((this.txtPesquisa.Text.Length <= 0) ? ((this.ComboBox1.SelectedIndex <= 0) ? ((this.ComboBox2.SelectedIndex <= 0) ? "" : ("Status2 = " + Conversions.ToString(num))) : ("Personagem = " + Conversions.ToString((int)(this.ComboBox1.SelectedIndex - 1)))) : ("Item LIKE '%" + this.txtPesquisa.Text + "%'")) : ("Personagem = " + Conversions.ToString((int)(this.ComboBox1.SelectedIndex - 1)) + " AND Status2 = " + Conversions.ToString(num))) : ("Item LIKE '%" + this.txtPesquisa.Text + "%' AND Status2 = " + Conversions.ToString(num))) : ("Item LIKE '%" + this.txtPesquisa.Text + "%' AND Personagem = " + Conversions.ToString((int)(this.ComboBox1.SelectedIndex - 1)));
                }
                else
                {
                    string[] strArray = new string[] { "Item LIKE '%", this.txtPesquisa.Text, "%' AND Personagem = ", Conversions.ToString((int)(this.ComboBox1.SelectedIndex - 1)), " AND Status2 = ", Conversions.ToString(num) };
                    this.bs.Filter = string.Concat(strArray);
                }
                this.Label33.Text = Conversions.ToString(this.bs.Count);
                this.ListaItem.Columns[0].Width = 0x2d;
                this.ListaItem.Columns[2].Width = 30;
                this.ListaItem.Columns[5].Width = 30;
                this.ListaItem.Columns[0].ValueType = typeof(int);
                this.ListaItem.Columns[2].HeaderText = "   ";
                this.ListaItem.Columns[5].HeaderText = "   ";
            }
            catch (Exception exception1)
            {
                Exception ex = exception1;
                ProjectData.SetProjectError(ex);
                Exception exception = ex;
                ProjectData.ClearProjectError();
            }
        }
        private void frmClubSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bwGerarSql.IsBusy | this.bwSalvar.IsBusy)
            {
                MessageBox.Show("Existem tarefas ainda em execu\x00e7\x00e3o, \x00e9 necess\x00e1rio aguardar o t\x00e9rmino destas tarefas", "Tarefas pendentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
           // MyProject.Forms.frmPrincipal.Show();
        }

        //private void frmClubSet_Load(object sender, EventArgs e)
        //{
        //    if (this.Arquivo != "")
        //    {
        //        try
        //        {
        //            this.ls = Util.dividirArquivo((List<string>)Util.lerArquivo(this.Arquivo, ref this.bStart, ref this.qtdItem, 200), 200);
        //        }
        //        catch (Exception exception1)
        //        {
        //                           MessageBox.Show("Pangya Modern Editor IFF", exception1.Message);
        //            Interaction.MsgBox("Tipo de arquivo descnhecido", MsgBoxStyle.ApplicationModal, null);

        //            return;
        //        }
        //        this.lsItens = new PangLib.IFF.IFFFile<PangLib.IFF.DataModels.Caddie>();
        //        int num3 = this.ls.Count - 1;
        //        for (int i = 0; i <= num3; i++)
        //        {
        //            this.oIff = new Caddie(this.ls[i]);
        //            this.lsItens.Add(this.oIff);
        //        }
        //        this.lsTemp.AddRange(this.lsItens.GetRange(0, this.lsItens.Count));
        //        int length = 0x19;
        //        if (Strings.Len(this.Arquivo) > 0x19)
        //        {
        //            this.lbArquivo.Text = "..." + this.Arquivo.Substring(Strings.Len(this.Arquivo) - length, length);
        //        }
        //        else
        //        {
        //            this.lbArquivo.Text = this.Arquivo;
        //        }
        //        this.ListaItem.DataSource = null;
        //        this.CarregarGrid(this.lsTemp);
        //        this.lbIndices.Text = Conversions.ToString(this.qtdItem);
        //    }
        //    this.ComboBox1.SelectedIndex = 0;
        //    this.ComboBox2.SelectedIndex = 0;
        //}

        private void gerarBarra(Control Barra, object sender1)
        {
            try
            {
                // Definindo algumas variáveis
                int num2 = 0;
                double num6 = 5.9;

                // Calculando a largura da barra com base no valor fornecido
                Barra.Width = Conversions.ToInteger(Operators.MultiplyObject(
                    NewLateBinding.LateGet(sender1, null, "value", new object[0], null, null, null), num6));

            }
            catch (Exception ex)
            {
                // Lidando com exceções, se ocorrerem
                Console.WriteLine("Ocorreu uma exceção: " + ex.Message);
            }
        }


        public void gerarSql(BackgroundWorker BW)
        {
            if (this.Arquivo == null)
            {
                MessageBox.Show("Arquivo inv\x00e1lido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            //else if (Convert.ToBoolean(Util.Caddie_gerarSql(this.lsTemp, this.Arquivo, ref BW)))
            //{
            //    MessageBox.Show("SQL gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
            //else
            //{
            //    MessageBox.Show("Arquivo salvo com erro!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}
        }
        private void ListaItem_DefaultCellStyleChanged(object sender, EventArgs e)
        {
            try
            {
                this.pintarLinhas();
            }
            catch (Exception exception1)
            {
                               MessageBox.Show("Pangya Modern Editor IFF", exception1.Message);
                
            }
        }

        private void ListaItem_MouseHover(object sender, EventArgs e)
        {
            if (this.Alterado)
            {
                if (MessageBox.Show("Existem altera\x00e7\x00f5es que n\x00e3o foram salvas, desaja salva-las agora?", "Confirma\x00e7\x00e3o", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.salvarAlteracoes();
                }
                else
                {
                    this.Alterado = false;
                }
            }
        }

        private void ListaItem_RowsDefaultCellStyleChanged(object sender, EventArgs e)
        {
            this.pintarLinhas();
        }

        private void listaItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.bwGerarSql.IsBusy | this.bwSalvar.IsBusy)
                {
                    this.btnSalvar.Enabled = false;
                }
                if (this.ListaItem.SelectedRows.Count > 1)
                {
                    this.gbBotoes.Enabled = true;
                    this.tabForm.Enabled = false;
                    this.txtPesquisa.Enabled = false;
                    this.btnNovo.Enabled = false;
                    this.btnBackup.Enabled = false;
                    this.btnSalvar.Enabled = false;
                    this.btnReabrir.Enabled = false;
                    this.menuSalvarComo.Enabled = true;
                    this.menuTypeid.Enabled = true;
                    this.menuBackup.Enabled = true;
                    this.menuGerarSql.Enabled = true;
                    this.menuMassa.Enabled = true;
                    this.menuDividir.Enabled = true;
                    this.menuGerarCache.Enabled = true;
                }
                else if (ListaItem.SelectedCells.Count > 0 && ListaItem.SelectedCells[0].RowIndex >= 0)
                {
                    this.btnNovo.Enabled = true;
                    this.btnBackup.Enabled = true;
                    this.btnSalvar.Enabled = true;
                    this.btnReabrir.Enabled = true;
                    this.gbBotoes.Enabled = true;
                    this.tabForm.Enabled = true;
                    this.txtPesquisa.Enabled = true;
                    this.menuSalvarComo.Enabled = true;
                    this.menuTypeid.Enabled = true;
                    this.menuBackup.Enabled = true;
                    this.menuGerarSql.Enabled = true;
                    this.menuMassa.Enabled = true;
                    this.menuDividir.Enabled = true;
                    this.menuGerarCache.Enabled = true;
                    this.CarregarItem();
                }
                else
                {
                    this.gbBotoes.Enabled = false;
                    this.tabForm.Enabled = false;
                    this.txtPesquisa.Enabled = false;
                    this.menuSalvarComo.Enabled = false;
                    this.menuTypeid.Enabled = false;
                    this.menuBackup.Enabled = false;
                    this.menuGerarSql.Enabled = false;
                    this.menuMassa.Enabled = false;
                    this.menuDividir.Enabled = false;
                    this.menuGerarCache.Enabled = false;
                }
                if (this.bwGerarSql.IsBusy | this.bwSalvar.IsBusy)
                {
                    this.btnSalvar.Enabled = false;
                }
                if (this.verificarTYPEID(0))
                {
                    this.txtTypeID.BackColor = Color.LightSalmon;
                }
                else
                {
                    this.txtTypeID.BackColor = Color.White;
                }
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private void ListaItem_Sorted(object sender, EventArgs e)
        {
            this.pintarLinhas();
        }

        private void menuGerarCache_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            List<string> list2 = new List<string>();
            foreach (Caddie caddie in this.lsTemp)
            {
                list.Add((int)caddie.ID);
                list2.Add(caddie.Icon);
            }
            //new frmCache
            //{
            //    ls = list,
            //    ls1 = list2,
            //    tipo = 1,
            //    TopMost = true
            //}.Show();
        }

        public void nomeArquivo()
        {
            int length = 0x19;
            if (Strings.Len(this.Arquivo) > 0x19)
            {
                this.lbArquivo.Text = "..." + this.Arquivo.Substring(Strings.Len(this.Arquivo) - length, length);
            }
            else
            {
                this.lbArquivo.Text = this.Arquivo;
            }
        }

        public void pintarLinhas()
        {
            int num2 = this.ListaItem.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                this.ListaItem.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                if (Operators.ConditionalCompareObjectEqual(this.ListaItem["Alterado", i].Value, 1, false))
                {
                    this.ListaItem.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCC00");
                }
                if (Operators.ConditionalCompareObjectEqual(this.ListaItem["Alterado", i].Value, 2, false))
                {
                    this.ListaItem.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#33CCFF");
                }
            }
            this.ListaItem.Columns[0].Width = 0x2d;
            this.ListaItem.Columns[2].Width = 30;
            this.ListaItem.Columns[5].Width = 30;
        }

        public void salvar(BackgroundWorker BW)
        {
            var bck = Path.ChangeExtension(Arquivo, ".bak");
            lsItens.Save(bck);
            lsTemp.Save(Arquivo);
            
        }

        private void salvarAlteracoes()
        {
            int num = Conversions.ToInteger(this.ListaItem.SelectedRows[0].Cells[0].Value);
            var caddie = lsTemp[num];
            if (this.ckAtivo.Checked)
            {
                caddie.Active = (byte)Conversions.ToLong("&H01");
            }
            else
            {
                caddie.Active = (byte)Conversions.ToLong("&H00");
            }
            caddie.MoneyFlag =Conversions.ToInteger("&H00");
            if (this.ckNew.Checked & this.ckGift.Checked)
            {
                caddie.MoneyFlag =Conversions.ToInteger("&H11");
            }
            else if (this.ckNew.Checked)
            {
                caddie.MoneyFlag = Conversions.ToInteger("&H13");
            }
            if (this.ckHot.Checked & this.ckGift.Checked)
            {
                caddie.MoneyFlag = Conversions.ToInteger("&H21");
            }
            else if (this.ckHot.Checked)
            {
                caddie.MoneyFlag = Conversions.ToInteger("&H23");
            }
            if (this.ckNormal.Checked & this.ckGift.Checked)
            {
                caddie.MoneyFlag = Conversions.ToInteger("&H01");
            }
            else if (this.ckNormal.Checked)
            {
                caddie.MoneyFlag = Conversions.ToInteger("&H03");
            }
            caddie.Name = this.txtNome.Text;
            caddie.Price = Conversions.ToUInteger(this.txtPreco.Text);
            caddie.ID = Conversions.ToUInteger(this.txtTypeID.Text);
            caddie.Icon = this.txtIcone.Text;
            caddie.ItemLevel = (byte)this.cbLevel.SelectedIndex;
            caddie.DiscountPrice = Conversions.ToUInteger(this.txtDesconto.Text);
            caddie.Power = Convert.ToUInt16(this.attForca.Value);
            caddie.Control = Convert.ToUInt16(this.attControle.Value);
            caddie.Impact = Convert.ToUInt16(this.attPrecisao.Value);
            caddie.Spin = Convert.ToUInt16(this.attSpin.Value);
            caddie.Curve = Convert.ToUInt16(this.attCurva.Value);
            caddie.Salary = Conversions.ToUInteger(this.txtSalary.Text);
            caddie.MPet = this.txtSprite.Text;
            if (this.rbLevelMin.Checked)
            {
                caddie.ItemLevel = (byte)this.cbLevel.SelectedIndex;
            }
            else
            {
                caddie.ItemLevel = (byte)(Conversions.ToLong("&H80") + this.cbLevel.SelectedIndex);
            }
            switch (this.cbTipo.SelectedIndex)
            {
                case 0:
                    caddie.ShopFlag = Conversions.ToInteger("&H00");
                    break;

                case 1:
                    caddie.ShopFlag = (int)Conversions.ToLong("&H01");
                    break;

                case 2:
                    caddie.ShopFlag = (int)Conversions.ToLong("&H02");
                    break;
            }
            if (this.ckTempoAtivo.Checked)
            {
                caddie.date.End.Day = (ushort)this.dtTermino.Value.Day;
                caddie.date.End.Month = (ushort)this.dtTermino.Value.Month;
                caddie.date.End.Year = (ushort)this.dtTermino.Value.Year;
                caddie.date.End.Hour = (ushort)this.dtTermino.Value.Hour;
                caddie.date.End.Minute = (ushort)this.dtTermino.Value.Minute;
                caddie.date.End.Second = (ushort)this.dtTermino.Value.Second;
                caddie.date.Start.Day = (ushort)this.dtInicio.Value.Day;
                caddie.date.Start.Month = (ushort)this.dtInicio.Value.Month;
                caddie.date.Start.Year = (ushort)this.dtInicio.Value.Year;
                caddie.date.Start.Hour = (ushort)this.dtInicio.Value.Hour;
                caddie.date.Start.Minute = (ushort)this.dtInicio.Value.Minute;
                caddie.date.Start.Second = (ushort)this.dtInicio.Value.Second;
                
            }
            this.ListaItem.SelectedRows[0].Cells[1].Value = this.txtNome.Text;
            this.ListaItem.SelectedRows[0].Cells["Alterado"].Value = 1;
            this.Alterado = false;
            this.qtdItem = this.ListaItem.Rows.Count;
        }

        private void MenuSalvarComo_Click(object sender, EventArgs e)
        {
            this.caminho = Conversions.ToString((int)this.diagSalvarArquivo.ShowDialog());
            this.Arquivo = this.diagSalvarArquivo.FileName;
            if (this.Arquivo != null)
            {
                this.bs.Filter = "";
                this.ComboBox1.SelectedIndex = 0;
                this.ComboBox2.SelectedIndex = 0;
                this.salvarAlteracoes();
                this.btnSalvar.Enabled = false;
                this.ToolStrip1.Enabled = false;
                this.bs.Filter = "";
                this.pbStatus.Style = ProgressBarStyle.Marquee;
                this.bwSalvar.RunWorkerAsync();
            }
        }

        private void MenuSalvarSQL_Click(object sender, EventArgs e)
        {
            this.caminho = Conversions.ToString((int)this.diagSalvarSql.ShowDialog());
            this.Arquivo = this.diagSalvarSql.FileName;
            if (this.Arquivo != null)
            {
                if (File.Exists(this.Arquivo))
                {
                    File.Delete(this.Arquivo);
                }
                this.btnSalvar.Enabled = false;
                this.ToolStrip1.Enabled = false;
                this.bwGerarSql.RunWorkerAsync();
            }
        }

        private void MenuSalvarBackup_Click(object sender, EventArgs e)
        {
            byte[] bs = (byte[])Util.setValues(this.lsTemp, this.bStart, this.qtdItem, true);
            bool data = true;
            int totalProc = 0;
            //if (Convert.ToBoolean(Util.gerarBackup(bs, MySettingsProperty.Settings.ArquivoIff, ref data, ref totalProc)))
            //{
            //    MessageBox.Show("Backup gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
            //else
            //{
            //    MessageBox.Show("Erro ao gerar o backup", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}
        }

        private void txtIcone_TextChanged(object sender, EventArgs e)
        {
            //PictureBox imgIcone = this.imgIcone;
            //this.carregarImagem(Conversions.ToString(Util.getImage(this.txtTypeID.Text, this.txtIcone.Text)), ref imgIcone);
            //this.imgIcone = imgIcone;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            this.lbContNome.Text = Conversions.ToString(this.txtNome.Text.Length) + "/40";
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            this.filtrar();
        }

        private bool verificarTYPEID(int typeid)
        {
            int num = 0;
            bool flag = false;
            if (typeid == 0)
            {
                typeid = Conversions.ToInteger(this.txtTypeID.Text);
            }
            else
            {
                flag = true;
            }
            foreach (Caddie caddie in this.lsTemp)
            {
                if (caddie.ID == typeid)
                {
                    num++;
                }
            }
            if (flag)
            {
                return (num >= 1);
            }
            return (num > 1);
        }

    }
}
