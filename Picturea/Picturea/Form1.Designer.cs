namespace Picturea
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("RGB");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Красный");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Зеленый");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Синий");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.open_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.save_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAs_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exit_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undo_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redo_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.transform_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightness_MenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quantize_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binarize_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScale_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invert_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convolution_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curves_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curve_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamma_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sCorrect_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hueSaturation_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Medianer_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edges_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplasian_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplasianOfGaussianMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorOverlay_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalBlur_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussian_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.histogramm_tabPage = new System.Windows.Forms.TabPage();
            this.histogramm_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.channels_tabPage = new System.Windows.Forms.TabPage();
            this.colors_listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colors_imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.history_tabPage = new System.Windows.Forms.TabPage();
            this.history_listView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.history_imageList = new System.Windows.Forms.ImageList(this.components);
            this.layers_tabPage = new System.Windows.Forms.TabPage();
            this.layers_listView = new System.Windows.Forms.ListView();
            this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.layers_imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addLayer_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.alpha_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.blendModes_comboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.rgb_StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.viewportPanel = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.Open_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Save_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveAs_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.transforms_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.curv_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.importFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.size_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.button_ScrollMinus = new System.Windows.Forms.Button();
            this.button_ScrollPlus = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.histogramm_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogramm_chart)).BeginInit();
            this.channels_tabPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.history_tabPage.SuspendLayout();
            this.layers_tabPage.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alpha_numericUpDown)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.viewportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.size_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.редактированиеToolStripMenuItem,
            this.изображениеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(967, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_MenuItem,
            this.toolStripSeparator1,
            this.save_MenuItem,
            this.saveAs_MenuItem,
            this.toolStripSeparator2,
            this.exit_MenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // open_MenuItem
            // 
            this.open_MenuItem.Name = "open_MenuItem";
            this.open_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.open_MenuItem.Text = "Открыть";
            this.open_MenuItem.Click += new System.EventHandler(this.open_MenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // save_MenuItem
            // 
            this.save_MenuItem.Name = "save_MenuItem";
            this.save_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.save_MenuItem.Text = "Сохранить";
            this.save_MenuItem.Click += new System.EventHandler(this.save_MenuItem_Click);
            // 
            // saveAs_MenuItem
            // 
            this.saveAs_MenuItem.Name = "saveAs_MenuItem";
            this.saveAs_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveAs_MenuItem.Text = "Сохранить как..";
            this.saveAs_MenuItem.Click += new System.EventHandler(this.saveAs_MenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // exit_MenuItem
            // 
            this.exit_MenuItem.Name = "exit_MenuItem";
            this.exit_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.exit_MenuItem.Text = "Выход";
            this.exit_MenuItem.Click += new System.EventHandler(this.exit_MenuItem_Click);
            // 
            // редактированиеToolStripMenuItem
            // 
            this.редактированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undo_MenuItem,
            this.redo_MenuItem,
            this.toolStripSeparator3,
            this.transform_MenuItem});
            this.редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            this.редактированиеToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.редактированиеToolStripMenuItem.Text = "Редактирование";
            // 
            // undo_MenuItem
            // 
            this.undo_MenuItem.Name = "undo_MenuItem";
            this.undo_MenuItem.Size = new System.Drawing.Size(172, 22);
            this.undo_MenuItem.Text = "Шаг назад";
            this.undo_MenuItem.Click += new System.EventHandler(this.undo_MenuItem_Click);
            // 
            // redo_MenuItem
            // 
            this.redo_MenuItem.Name = "redo_MenuItem";
            this.redo_MenuItem.Size = new System.Drawing.Size(172, 22);
            this.redo_MenuItem.Text = "Шаг вперед";
            this.redo_MenuItem.Click += new System.EventHandler(this.redo_MenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // transform_MenuItem
            // 
            this.transform_MenuItem.Name = "transform_MenuItem";
            this.transform_MenuItem.Size = new System.Drawing.Size(172, 22);
            this.transform_MenuItem.Text = "Трансформации..";
            this.transform_MenuItem.Click += new System.EventHandler(this.transform_MenuItem_Click);
            // 
            // изображениеToolStripMenuItem
            // 
            this.изображениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brightness_MenuItem1,
            this.quantize_MenuItem,
            this.binarize_MenuItem,
            this.grayScale_MenuItem,
            this.invert_MenuItem,
            this.convolution_MenuItem,
            this.curves_MenuItem,
            this.hueSaturation_MenuItem,
            this.Medianer_MenuItem,
            this.edges_MenuItem,
            this.ColorOverlay_MenuItem,
            this.normalBlur_MenuItem,
            this.gaussian_MenuItem});
            this.изображениеToolStripMenuItem.Name = "изображениеToolStripMenuItem";
            this.изображениеToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.изображениеToolStripMenuItem.Text = "Изображение";
            // 
            // brightness_MenuItem1
            // 
            this.brightness_MenuItem1.Name = "brightness_MenuItem1";
            this.brightness_MenuItem1.Size = new System.Drawing.Size(245, 22);
            this.brightness_MenuItem1.Text = "Яркость/Контрастность..";
            this.brightness_MenuItem1.Click += new System.EventHandler(this.brightnessNContrast_MenuItem_Click);
            // 
            // quantize_MenuItem
            // 
            this.quantize_MenuItem.Name = "quantize_MenuItem";
            this.quantize_MenuItem.Size = new System.Drawing.Size(245, 22);
            this.quantize_MenuItem.Text = "Палитра..";
            this.quantize_MenuItem.Click += new System.EventHandler(this.quantize_MenuItem_Click);
            // 
            // binarize_MenuItem
            // 
            this.binarize_MenuItem.Name = "binarize_MenuItem";
            this.binarize_MenuItem.Size = new System.Drawing.Size(245, 22);
            this.binarize_MenuItem.Text = "Бинаризация..";
            this.binarize_MenuItem.Click += new System.EventHandler(this.binarize_MenuItem_Click);
            // 
            // grayScale_MenuItem
            // 
            this.grayScale_MenuItem.Name = "grayScale_MenuItem";
            this.grayScale_MenuItem.Size = new System.Drawing.Size(245, 22);
            this.grayScale_MenuItem.Text = "Удаление цвета";
            this.grayScale_MenuItem.Click += new System.EventHandler(this.grayScale_MenuItem_Click);
            // 
            // invert_MenuItem
            // 
            this.invert_MenuItem.Name = "invert_MenuItem";
            this.invert_MenuItem.Size = new System.Drawing.Size(245, 22);
            this.invert_MenuItem.Text = "Инверсия";
            this.invert_MenuItem.Click += new System.EventHandler(this.invert_MenuItem_Click);
            // 
            // convolution_MenuItem
            // 
            this.convolution_MenuItem.Name = "convolution_MenuItem";
            this.convolution_MenuItem.Size = new System.Drawing.Size(245, 22);
            this.convolution_MenuItem.Text = "Матрица свертки..";
            this.convolution_MenuItem.Click += new System.EventHandler(this.convolution_MenuItem_Click);
            // 
            // curves_MenuItem
            // 
            this.curves_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.curve_MenuItem,
            this.gamma_MenuItem,
            this.sCorrect_MenuItem});
            this.curves_MenuItem.Name = "curves_MenuItem";
            this.curves_MenuItem.Size = new System.Drawing.Size(245, 22);
            this.curves_MenuItem.Text = "Кривые";
            // 
            // curve_MenuItem
            // 
            this.curve_MenuItem.Name = "curve_MenuItem";
            this.curve_MenuItem.Size = new System.Drawing.Size(169, 22);
            this.curve_MenuItem.Text = "По кривой";
            this.curve_MenuItem.Click += new System.EventHandler(this.curve_MenuItem_Click);
            // 
            // gamma_MenuItem
            // 
            this.gamma_MenuItem.Name = "gamma_MenuItem";
            this.gamma_MenuItem.Size = new System.Drawing.Size(169, 22);
            this.gamma_MenuItem.Text = "По гамма";
            this.gamma_MenuItem.Click += new System.EventHandler(this.gamma_MenuItem_Click);
            // 
            // sCorrect_MenuItem
            // 
            this.sCorrect_MenuItem.Name = "sCorrect_MenuItem";
            this.sCorrect_MenuItem.Size = new System.Drawing.Size(169, 22);
            this.sCorrect_MenuItem.Text = "По S - коррекция";
            this.sCorrect_MenuItem.Click += new System.EventHandler(this.sCorrect_MenuItem_Click);
            // 
            // hueSaturation_MenuItem
            // 
            this.hueSaturation_MenuItem.Name = "hueSaturation_MenuItem";
            this.hueSaturation_MenuItem.Size = new System.Drawing.Size(245, 22);
            this.hueSaturation_MenuItem.Text = "Цветовой тон/Насыщенность..";
            this.hueSaturation_MenuItem.Click += new System.EventHandler(this.hueSaturation_MenuItem_Click);
            // 
            // Medianer_MenuItem
            // 
            this.Medianer_MenuItem.Name = "Medianer_MenuItem";
            this.Medianer_MenuItem.Size = new System.Drawing.Size(245, 22);
            this.Medianer_MenuItem.Text = "Медианер";
            this.Medianer_MenuItem.Click += new System.EventHandler(this.Medianer_MenuItem_Click);
            // 
            // edges_MenuItem
            // 
            this.edges_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.laplasian_MenuItem,
            this.laplasianOfGaussianMenuItem});
            this.edges_MenuItem.Name = "edges_MenuItem";
            this.edges_MenuItem.Size = new System.Drawing.Size(245, 22);
            this.edges_MenuItem.Text = "Усиление границ..";
            // 
            // laplasian_MenuItem
            // 
            this.laplasian_MenuItem.Name = "laplasian_MenuItem";
            this.laplasian_MenuItem.Size = new System.Drawing.Size(197, 22);
            this.laplasian_MenuItem.Text = "По Лапласу";
            this.laplasian_MenuItem.Click += new System.EventHandler(this.laplasian_MenuItem_Click);
            // 
            // laplasianOfGaussianMenuItem
            // 
            this.laplasianOfGaussianMenuItem.Name = "laplasianOfGaussianMenuItem";
            this.laplasianOfGaussianMenuItem.Size = new System.Drawing.Size(197, 22);
            this.laplasianOfGaussianMenuItem.Text = "По Лапласу с Гауссом";
            this.laplasianOfGaussianMenuItem.Click += new System.EventHandler(this.laplasianOfGaussianMenuItem_Click);
            // 
            // ColorOverlay_MenuItem
            // 
            this.ColorOverlay_MenuItem.Name = "ColorOverlay_MenuItem";
            this.ColorOverlay_MenuItem.Size = new System.Drawing.Size(245, 22);
            this.ColorOverlay_MenuItem.Text = "Наложение цвета..";
            this.ColorOverlay_MenuItem.Click += new System.EventHandler(this.ColorOverlay_MenuItem_Click);
            // 
            // normalBlur_MenuItem
            // 
            this.normalBlur_MenuItem.Name = "normalBlur_MenuItem";
            this.normalBlur_MenuItem.Size = new System.Drawing.Size(245, 22);
            this.normalBlur_MenuItem.Text = "Усредненное размытие";
            this.normalBlur_MenuItem.Click += new System.EventHandler(this.normalBlur_MenuItem_Click);
            // 
            // gaussian_MenuItem
            // 
            this.gaussian_MenuItem.Name = "gaussian_MenuItem";
            this.gaussian_MenuItem.Size = new System.Drawing.Size(245, 22);
            this.gaussian_MenuItem.Text = "Размытие по Гауссу..";
            this.gaussian_MenuItem.Click += new System.EventHandler(this.gaussian_MenuItem_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Location = new System.Drawing.Point(637, 60);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer.Size = new System.Drawing.Size(330, 386);
            this.splitContainer.SplitterDistance = 115;
            this.splitContainer.TabIndex = 4;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.histogramm_tabPage);
            this.tabControl2.Controls.Add(this.channels_tabPage);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(328, 113);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 0;
            // 
            // histogramm_tabPage
            // 
            this.histogramm_tabPage.Controls.Add(this.histogramm_chart);
            this.histogramm_tabPage.Location = new System.Drawing.Point(4, 22);
            this.histogramm_tabPage.Name = "histogramm_tabPage";
            this.histogramm_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.histogramm_tabPage.Size = new System.Drawing.Size(320, 87);
            this.histogramm_tabPage.TabIndex = 0;
            this.histogramm_tabPage.Text = "Гистограмма";
            this.histogramm_tabPage.UseVisualStyleBackColor = true;
            // 
            // histogramm_chart
            // 
            this.histogramm_chart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.histogramm_chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            chartArea3.AlignmentStyle = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentStyles.None;
            chartArea3.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea3.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea3.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.BorderColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.histogramm_chart.ChartAreas.Add(chartArea3);
            this.histogramm_chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramm_chart.Location = new System.Drawing.Point(3, 3);
            this.histogramm_chart.Name = "histogramm_chart";
            this.histogramm_chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.histogramm_chart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.MediumAquamarine};
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series3.Name = "Series1";
            this.histogramm_chart.Series.Add(series3);
            this.histogramm_chart.Size = new System.Drawing.Size(314, 81);
            this.histogramm_chart.TabIndex = 0;
            this.histogramm_chart.Text = "chart1";
            // 
            // channels_tabPage
            // 
            this.channels_tabPage.Controls.Add(this.colors_listView);
            this.channels_tabPage.Location = new System.Drawing.Point(4, 22);
            this.channels_tabPage.Name = "channels_tabPage";
            this.channels_tabPage.Size = new System.Drawing.Size(320, 87);
            this.channels_tabPage.TabIndex = 1;
            this.channels_tabPage.Text = "Цвета";
            this.channels_tabPage.UseVisualStyleBackColor = true;
            // 
            // colors_listView
            // 
            this.colors_listView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.colors_listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.colors_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.colors_listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colors_listView.FullRowSelect = true;
            this.colors_listView.GridLines = true;
            this.colors_listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.colors_listView.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            this.colors_listView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.colors_listView.LabelWrap = false;
            this.colors_listView.Location = new System.Drawing.Point(0, 0);
            this.colors_listView.MultiSelect = false;
            this.colors_listView.Name = "colors_listView";
            this.colors_listView.ShowGroups = false;
            this.colors_listView.Size = new System.Drawing.Size(320, 87);
            this.colors_listView.SmallImageList = this.colors_imageList;
            this.colors_listView.TabIndex = 1;
            this.colors_listView.UseCompatibleStateImageBehavior = false;
            this.colors_listView.View = System.Windows.Forms.View.Details;
            this.colors_listView.SelectedIndexChanged += new System.EventHandler(this.colors_listView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 200;
            // 
            // colors_imageList
            // 
            this.colors_imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.colors_imageList.ImageSize = new System.Drawing.Size(50, 37);
            this.colors_imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.history_tabPage);
            this.tabControl1.Controls.Add(this.layers_tabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 21);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(3, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(328, 265);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // history_tabPage
            // 
            this.history_tabPage.Controls.Add(this.history_listView);
            this.history_tabPage.Location = new System.Drawing.Point(4, 25);
            this.history_tabPage.Name = "history_tabPage";
            this.history_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.history_tabPage.Size = new System.Drawing.Size(320, 236);
            this.history_tabPage.TabIndex = 1;
            this.history_tabPage.Text = "История";
            this.history_tabPage.UseVisualStyleBackColor = true;
            // 
            // history_listView
            // 
            this.history_listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.history_listView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.history_listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.history_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.history_listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.history_listView.FullRowSelect = true;
            this.history_listView.GridLines = true;
            this.history_listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.history_listView.HideSelection = false;
            this.history_listView.LabelWrap = false;
            this.history_listView.LargeImageList = this.history_imageList;
            this.history_listView.Location = new System.Drawing.Point(3, 3);
            this.history_listView.MultiSelect = false;
            this.history_listView.Name = "history_listView";
            this.history_listView.ShowGroups = false;
            this.history_listView.Size = new System.Drawing.Size(314, 230);
            this.history_listView.SmallImageList = this.history_imageList;
            this.history_listView.TabIndex = 2;
            this.history_listView.UseCompatibleStateImageBehavior = false;
            this.history_listView.View = System.Windows.Forms.View.Details;
            this.history_listView.SelectedIndexChanged += new System.EventHandler(this.history_listView_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 150;
            // 
            // history_imageList
            // 
            this.history_imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.history_imageList.ImageSize = new System.Drawing.Size(50, 37);
            this.history_imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // layers_tabPage
            // 
            this.layers_tabPage.Controls.Add(this.layers_listView);
            this.layers_tabPage.Controls.Add(this.toolStrip1);
            this.layers_tabPage.Controls.Add(this.panel1);
            this.layers_tabPage.Location = new System.Drawing.Point(4, 25);
            this.layers_tabPage.Name = "layers_tabPage";
            this.layers_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.layers_tabPage.Size = new System.Drawing.Size(320, 236);
            this.layers_tabPage.TabIndex = 0;
            this.layers_tabPage.Text = "Слои";
            this.layers_tabPage.UseVisualStyleBackColor = true;
            // 
            // layers_listView
            // 
            this.layers_listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.layers_listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layers_listView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.layers_listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.layers_listView.CheckBoxes = true;
            this.layers_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
            this.layers_listView.FullRowSelect = true;
            this.layers_listView.GridLines = true;
            this.layers_listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.layers_listView.HideSelection = false;
            this.layers_listView.LabelWrap = false;
            this.layers_listView.LargeImageList = this.layers_imageList;
            this.layers_listView.Location = new System.Drawing.Point(3, 33);
            this.layers_listView.MultiSelect = false;
            this.layers_listView.Name = "layers_listView";
            this.layers_listView.ShowGroups = false;
            this.layers_listView.Size = new System.Drawing.Size(315, 176);
            this.layers_listView.SmallImageList = this.layers_imageList;
            this.layers_listView.TabIndex = 0;
            this.layers_listView.UseCompatibleStateImageBehavior = false;
            this.layers_listView.View = System.Windows.Forms.View.Details;
            this.layers_listView.SelectedIndexChanged += new System.EventHandler(this.layers_listView_SelectedIndexChanged);
            // 
            // columnHeader
            // 
            this.columnHeader.Width = 150;
            // 
            // layers_imageList
            // 
            this.layers_imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.layers_imageList.ImageSize = new System.Drawing.Size(50, 37);
            this.layers_imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLayer_toolStripButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(3, 208);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(314, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addLayer_toolStripButton
            // 
            this.addLayer_toolStripButton.BackColor = System.Drawing.Color.Gainsboro;
            this.addLayer_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addLayer_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addLayer_toolStripButton.Name = "addLayer_toolStripButton";
            this.addLayer_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addLayer_toolStripButton.Text = "toolStripButton1";
            this.addLayer_toolStripButton.Click += new System.EventHandler(this.addLayer_toolStripButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panel1.Controls.Add(this.alpha_numericUpDown);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.blendModes_comboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 28);
            this.panel1.TabIndex = 2;
            // 
            // alpha_numericUpDown
            // 
            this.alpha_numericUpDown.Location = new System.Drawing.Point(262, 4);
            this.alpha_numericUpDown.Name = "alpha_numericUpDown";
            this.alpha_numericUpDown.Size = new System.Drawing.Size(49, 20);
            this.alpha_numericUpDown.TabIndex = 3;
            this.alpha_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.alpha_numericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.alpha_numericUpDown.ValueChanged += new System.EventHandler(this.alpha_numericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(169, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Непрозрачность";
            // 
            // blendModes_comboBox
            // 
            this.blendModes_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.blendModes_comboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.blendModes_comboBox.Items.AddRange(new object[] {
            "Обычный",
            "Разница",
            "Исключение"});
            this.blendModes_comboBox.Location = new System.Drawing.Point(3, 3);
            this.blendModes_comboBox.Name = "blendModes_comboBox";
            this.blendModes_comboBox.Size = new System.Drawing.Size(148, 21);
            this.blendModes_comboBox.TabIndex = 0;
            this.blendModes_comboBox.SelectionChangeCommitted += new System.EventHandler(this.blendModes_comboBox_SelectionChangeCommitted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rgb_StatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(967, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // rgb_StatusLabel1
            // 
            this.rgb_StatusLabel1.Name = "rgb_StatusLabel1";
            this.rgb_StatusLabel1.Padding = new System.Windows.Forms.Padding(140, 0, 0, 0);
            this.rgb_StatusLabel1.Size = new System.Drawing.Size(140, 17);
            this.rgb_StatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // viewportPanel
            // 
            this.viewportPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewportPanel.AutoScroll = true;
            this.viewportPanel.BackColor = System.Drawing.Color.Honeydew;
            this.viewportPanel.Controls.Add(this.pictureBox);
            this.viewportPanel.Location = new System.Drawing.Point(0, 57);
            this.viewportPanel.Name = "viewportPanel";
            this.viewportPanel.Size = new System.Drawing.Size(638, 389);
            this.viewportPanel.TabIndex = 6;
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImage = global::Picturea.Properties.Resources.Background;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Location = new System.Drawing.Point(33, 44);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(573, 317);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "pll|*.pll|jpg|*.jpg;*.jpeg|bmp|*.bmp|tiff|*.tif;*.tiff|Все файлы|*.*";
            this.openFileDialog.FilterIndex = 5;
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AllowMerge = false;
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.toolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_toolStripButton,
            this.toolStripSeparator4,
            this.Save_toolStripButton,
            this.SaveAs_toolStripButton,
            this.toolStripSeparator5,
            this.transforms_toolStripButton,
            this.curv_toolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 24);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(967, 34);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // Open_toolStripButton
            // 
            this.Open_toolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Open_toolStripButton.ForeColor = System.Drawing.SystemColors.Control;
            this.Open_toolStripButton.Image = global::Picturea.Properties.Resources.icon_94_folder;
            this.Open_toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Open_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open_toolStripButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Open_toolStripButton.Name = "Open_toolStripButton";
            this.Open_toolStripButton.Size = new System.Drawing.Size(38, 32);
            this.Open_toolStripButton.Text = "         ";
            this.Open_toolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.Open_toolStripButton.ToolTipText = "Открыть";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 34);
            // 
            // Save_toolStripButton
            // 
            this.Save_toolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Save_toolStripButton.Image = global::Picturea.Properties.Resources.icon_98_folder_upload;
            this.Save_toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Save_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save_toolStripButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Save_toolStripButton.Name = "Save_toolStripButton";
            this.Save_toolStripButton.Size = new System.Drawing.Size(36, 32);
            this.Save_toolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.Save_toolStripButton.ToolTipText = "Сохранить";
            this.Save_toolStripButton.Click += new System.EventHandler(this.Save_toolStripButton_Click);
            // 
            // SaveAs_toolStripButton
            // 
            this.SaveAs_toolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SaveAs_toolStripButton.Image = global::Picturea.Properties.Resources.icon_98_folder_uploadAs;
            this.SaveAs_toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveAs_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAs_toolStripButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.SaveAs_toolStripButton.Name = "SaveAs_toolStripButton";
            this.SaveAs_toolStripButton.Size = new System.Drawing.Size(36, 32);
            this.SaveAs_toolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.SaveAs_toolStripButton.ToolTipText = "Сохранить как..";
            this.SaveAs_toolStripButton.Click += new System.EventHandler(this.SaveAs_toolStripButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 34);
            // 
            // transforms_toolStripButton
            // 
            this.transforms_toolStripButton.AutoSize = false;
            this.transforms_toolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.transforms_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.transforms_toolStripButton.Image = global::Picturea.Properties.Resources._022_path_shape_points_anchor_transform_free_tool_object_vector_circle_oval_edit_48;
            this.transforms_toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.transforms_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.transforms_toolStripButton.Margin = new System.Windows.Forms.Padding(0);
            this.transforms_toolStripButton.Name = "transforms_toolStripButton";
            this.transforms_toolStripButton.Size = new System.Drawing.Size(36, 36);
            this.transforms_toolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.transforms_toolStripButton.ToolTipText = "Трансформации";
            this.transforms_toolStripButton.Click += new System.EventHandler(this.transforms_toolStripButton_Click);
            // 
            // curv_toolStripButton
            // 
            this.curv_toolStripButton.AutoSize = false;
            this.curv_toolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.curv_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.curv_toolStripButton.Image = global::Picturea.Properties.Resources.curv;
            this.curv_toolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.curv_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.curv_toolStripButton.Margin = new System.Windows.Forms.Padding(0);
            this.curv_toolStripButton.Name = "curv_toolStripButton";
            this.curv_toolStripButton.Size = new System.Drawing.Size(37, 37);
            this.curv_toolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.curv_toolStripButton.ToolTipText = "Кривые";
            this.curv_toolStripButton.Click += new System.EventHandler(this.curv_toolStripButton_Click);
            // 
            // importFileDialog1
            // 
            this.importFileDialog1.Filter = "jpg|*.jpg";
            this.importFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.importFileDialog1_FileOk);
            // 
            // size_numericUpDown
            // 
            this.size_numericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.size_numericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.size_numericUpDown.Location = new System.Drawing.Point(30, 447);
            this.size_numericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.size_numericUpDown.Name = "size_numericUpDown";
            this.size_numericUpDown.Size = new System.Drawing.Size(56, 20);
            this.size_numericUpDown.TabIndex = 8;
            this.size_numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.size_numericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.size_numericUpDown.ValueChanged += new System.EventHandler(this.size_numericUpDown_ValueChanged);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "pll|*.pll|jpg|*.jpg;*.jpeg|bmp|*.bmp|tiff|*.tif;*.tiff";
            // 
            // button_ScrollMinus
            // 
            this.button_ScrollMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_ScrollMinus.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button_ScrollMinus.BackgroundImage = global::Picturea.Properties.Resources.icon_113_search_minus;
            this.button_ScrollMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ScrollMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ScrollMinus.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_ScrollMinus.FlatAppearance.BorderSize = 0;
            this.button_ScrollMinus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.button_ScrollMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ScrollMinus.Location = new System.Drawing.Point(5, 445);
            this.button_ScrollMinus.Name = "button_ScrollMinus";
            this.button_ScrollMinus.Size = new System.Drawing.Size(25, 25);
            this.button_ScrollMinus.TabIndex = 10;
            this.button_ScrollMinus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_ScrollMinus.UseVisualStyleBackColor = false;
            this.button_ScrollMinus.Click += new System.EventHandler(this.button_ScrollMinus_Click);
            // 
            // button_ScrollPlus
            // 
            this.button_ScrollPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_ScrollPlus.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button_ScrollPlus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_ScrollPlus.BackgroundImage")));
            this.button_ScrollPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ScrollPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ScrollPlus.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_ScrollPlus.FlatAppearance.BorderSize = 0;
            this.button_ScrollPlus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.button_ScrollPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ScrollPlus.Location = new System.Drawing.Point(90, 445);
            this.button_ScrollPlus.Name = "button_ScrollPlus";
            this.button_ScrollPlus.Size = new System.Drawing.Size(25, 23);
            this.button_ScrollPlus.TabIndex = 9;
            this.button_ScrollPlus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_ScrollPlus.UseVisualStyleBackColor = false;
            this.button_ScrollPlus.Click += new System.EventHandler(this.button_ScrollPlus_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(967, 467);
            this.Controls.Add(this.button_ScrollMinus);
            this.Controls.Add(this.button_ScrollPlus);
            this.Controls.Add(this.size_numericUpDown);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.viewportPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Picture BOOM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.histogramm_tabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.histogramm_chart)).EndInit();
            this.channels_tabPage.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.history_tabPage.ResumeLayout(false);
            this.layers_tabPage.ResumeLayout(false);
            this.layers_tabPage.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alpha_numericUpDown)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.viewportPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.size_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transform_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem изображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quantize_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem binarize_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayScale_MenuItem;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem invert_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem open_MenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem save_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAs_MenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exit_MenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel rgb_StatusLabel1;
        private System.Windows.Forms.Panel viewportPanel;
        private System.Windows.Forms.ListView layers_listView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addLayer_toolStripButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader columnHeader;
        private System.Windows.Forms.ImageList layers_imageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox blendModes_comboBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage layers_tabPage;
        private System.Windows.Forms.TabPage history_tabPage;
        private System.Windows.Forms.NumericUpDown alpha_numericUpDown;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton Open_toolStripButton;
        private System.Windows.Forms.OpenFileDialog importFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem convolution_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem curves_MenuItem;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage histogramm_tabPage;
        private System.Windows.Forms.DataVisualization.Charting.Chart histogramm_chart;
        private System.Windows.Forms.ToolStripMenuItem Medianer_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem edges_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColorOverlay_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalBlur_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussian_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem hueSaturation_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightness_MenuItem1;
        private System.Windows.Forms.ToolStripMenuItem laplasian_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplasianOfGaussianMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curve_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamma_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem sCorrect_MenuItem;
        private System.Windows.Forms.NumericUpDown size_numericUpDown;
        private System.Windows.Forms.Button button_ScrollPlus;
        private System.Windows.Forms.Button button_ScrollMinus;
        private System.Windows.Forms.TabPage channels_tabPage;
        private System.Windows.Forms.ListView colors_listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView history_listView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList history_imageList;
        private System.Windows.Forms.ImageList colors_imageList;
        private System.Windows.Forms.ToolStripMenuItem undo_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem redo_MenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton Save_toolStripButton;
        private System.Windows.Forms.ToolStripButton SaveAs_toolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton transforms_toolStripButton;
        private System.Windows.Forms.ToolStripButton curv_toolStripButton;
    }
}

