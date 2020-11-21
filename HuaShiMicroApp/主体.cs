using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HuaShiMicroApp.Util;
using System.Threading;
using HuaShiMicroApp.Bean;
using HuaShiMicroApp.Bean.Enum;

namespace HuaShiMicroApp
{
    public partial class ImageForm : Form
    {
        public ImageForm()
        {
            InitializeComponent();
        }

        Random random = new Random();

        //第二张图片位置编号
        private String secondImageIndex;

        // 开始标志
        private bool started = false;

        // 训练开始
        private bool testSwitch = false;

        // 启动结果选择
        private bool enableJudge = false;

        //总共的组数
        public int totalNum;

        //当前是第几组
        public int currentNum;

        // 当前展示方式
        public ShowType currentShowType;

        public DisappearType currentDisappearType;

        public Point currentSecondImagePoint;

        public int finalRandIndex;

        public List<String> group1Images;

        public List<String> group2Images;

        // 当前展示过的两个图像
        public List<String> currentShowImages;

        //
        public int image1DisableTime;


        //保存用户的所有结果
        public List<Result> allResult = new List<Result>();

        //随机方式的容器
        RandStatusContainer randStatusContainer;
        // 图片的位置
        private Point imageCenterPoint;
        private Point imageLeftPoint;
        private Point imageRightPoint;
        private Point imageUpPoint;
        private Point imageDownPoint;
        private Point trainResultLabelPoint;


        private void ImageForm_Load(object sender, EventArgs e)
        {
            // trian
            initLocation();
            setLocation();
            loadInformation();
            initTimer();
            loadImagePath("train");
        }

        private void showFocusPoint()
        {
            if (this.currentNum >= this.totalNum)
            {
                if (this.testSwitch)
                {
                    wirteToTxt();
                    MessageBox.Show("实验完成! 感谢您的参与! 确认即可退出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // 将结果写入到文件
                    //
                    System.Environment.Exit(System.Environment.ExitCode);
                    this.Dispose();
                    this.Close();
                }
                else {
                    //清空当前的结果
                    this.allResult.Clear();
                    DialogResult result = MessageBox.Show("训练完成! 确认即可进入测试，取消可重新训练！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    // 取消重新进行训练
                    if (result == DialogResult.Cancel) {
                        this.loadImagePath("train");
                        this.currentNum = 0;
                    }
                    if (result == DialogResult.OK) {
                        this.loadImagePath("test");
                        this.testSwitch = true;
                        this.Mode.Text = "实验模式";
                        this.currentNum = 0;
                    }
                }
            }
            //加载注视点图片，位于正中间, 注视点图片保持原大小
            this.imageBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            this.imageBox1.Location = this.imageCenterPoint;
            this.imageBox1.Visible = true;
            //打开状态栏
            
            //打开定时器
            this.timer3Focus.Start();
            imageBox1.Load(String.Format("{0}image\\focus.bmp", AppDomain.CurrentDomain.BaseDirectory));
            //同时加载要显示的随机流程
            this.getShowImageType();

        }

        //初始化点位
        private void initLocation()
        {
            this.trainResultLabelPoint = LayoutUtil.getCenterLocation(this, this.trainResultLabel);
            this.imageCenterPoint = LayoutUtil.getCenterLocation(this, this.imageBox1);
            this.imageLeftPoint = LayoutUtil.getLeftLocation(this, this.imageBox1);
            this.imageRightPoint = LayoutUtil.getRightLocation(this, this.imageBox1);
            this.imageUpPoint = LayoutUtil.getUpLocation(this, this.imageBox1);
            this.imageDownPoint = LayoutUtil.getDownLocation(this, this.imageBox1);
        }

        //从集合中随机抽取一张图片，然后返回抽出图片后的图片集合
        private int randImage(List<String> images)
        {
            int randIndex = random.Next(0, images.Count);
            return randIndex;
        }

        //点击开始图片放映
        private void Start_Click(object sender, EventArgs e)
        {
            this.Mode.Text = "训练模式";
            //隐藏按钮和文本框
            ControlUtils.closeTextBox(this.informationText);
            // 显示注视点500ms
            ControlUtils.showPictureBox(this.imageBox1);
            this.showFocusPoint();
        }   

        /// <summary>
        /// 1.定时器1计时结束,关闭计时器1.
        /// 2.抽取第二组图片，显示第二组的抽取的图片,并开启定时器2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            //图1消失的逻辑
            if (currentDisappearType == DisappearType.DISAPPEAR_ORDER) { 
               //空屏300ms
                imageBox1.Visible = false;
            }
            Thread.Sleep(this.image1DisableTime);
            //第二张图片的位置随机
            imageBox2.Location = this.currentSecondImagePoint;
            imageBox2.Visible = true;
            imageBox2.Load(currentShowImages[1]);
            // 初始化一个结果
            //if (this.testSwitch)
            //{
                allResult.Add(this.initResult(this.currentNum));
            //}
            this.enableJudge = true;
            //第二张图片出现的时候开始计时,等待3s进行选择
            this.waitChooseTime.Enabled = true;
            this.waitChooseTime.Start();
        }

        /// <summary>
        /// 聚焦图片的延时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3Focus_Tick(object sender, EventArgs e)
        {
            timer3Focus.Stop();
            this.imageBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //关掉注视点图片
            //继续显示第一张图片
            this.showImages();
        }



        /// <summary>
        /// 加载必读信息
        /// </summary>
        private void loadInformation()
        {
            this.informationText.Text = ConfigAppSettings.GetValue("information");
            this.informationText.Enabled = false;
            this.informationText.Visible = true;
        }

        /// <summary>
        /// 初始化定时器
        /// </summary>
        private void initTimer()
        {
            timer1.Stop();
            timer3Focus.Stop();
            waitChooseTime.Stop();
            // 加载必读信息
            int interval1 = 1000;
            int intervalFocusPoint = 500;
            this.image1DisableTime = 300;
            int.TryParse(ConfigAppSettings.GetValue("image1DisplayTime"), out interval1);
            int.TryParse(ConfigAppSettings.GetValue("image1DisableTime"), out this.image1DisableTime);
            // 设置定时器的间隔
            timer1.Interval = interval1;
            timer3Focus.Interval = intervalFocusPoint;
            waitChooseTime.Interval = 3000;
        }

        /// <summary>
        /// 加载图片的路径
        /// </summary>
        private void loadImagePath(String type)
        {
            //获取exe执行的路径
            String rootPath = AppDomain.CurrentDomain.BaseDirectory;
            //拼接上group1和group2两个路径
            String group1Directory;
            String group2Directory;
            if (type == "test")
            {
                group1Directory = String.Format("{0}group1", rootPath);
                group2Directory = String.Format("{0}group2", rootPath);
            }
            else
            {
                group1Directory = String.Format("{0}train1", rootPath);
                group2Directory = String.Format("{0}train2", rootPath);
            }
            //列出所有的文件
            String[] group1Paths = Directory.GetFiles(group1Directory);
            group1Images = new List<String>(group1Paths);
            String[] group2Paths = Directory.GetFiles(group2Directory);
            group2Images = new List<String>(group2Paths);
            int group1Size = group1Images.Count();
            int group2Size = group2Images.Count();
            this.totalNum = Math.Min(group1Size, group2Size);//总共显示的组数
            this.randStatusContainer = new RandStatusContainer(totalNum, this, this.imageBox1);
        }

        /// <summary>
        /// 初始化一个结果，接受参数时第几组
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private Result initResult(int i)
        {
            Result result = new Result();
            result.index = i;
            result.setStartTime();
            return result;
        }

        private void saveResult(int randIndex, int chooseIndex)
        {
            Result result = allResult[currentNum - 1];
            result.setEndTime();
            result.setChooseIfCorrect(randIndex, chooseIndex);
            result.setType(this.currentShowType, this.currentDisappearType, this.secondImageIndex);
        }

        /// <summary>
        /// 将结果写入到文件 result.Txt
        /// </summary>
        private void wirteToTxt()
        {
            String info = String.Join("\r\n", allResult.ConvertAll(x => x.ToString()).ToArray());
            String rootPath = AppDomain.CurrentDomain.BaseDirectory;
            FileUtil.WriteToFile(String.Format("{0}result.txt", rootPath), info, true);
        }

        //为各个控件设置对应的位置
        private void setLocation()
        {
            //文本显示框
            informationText.Location = new Point()
            {
                X = this.Width / 2 - informationText.Size.Width / 2,
                Y = this.Height / 2 - informationText.Size.Height / 2 - 100
            };

            // 图片显示框
            imageBox1.Location = new Point()
            {
                X = this.Width / 2 - imageBox1.Size.Width / 2,
                Y = 75
            };
            //设置注视点位置
        }

        // 当按键按下Q，并且程序未开始的时候生效
        private void ImageForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q && !this.started)
            {
                this.started = true;
                this.Start_Click(sender, e);
            }
            // 选择人物
            if (e.KeyCode == Keys.Left && this.enableJudge)
            {
                //做出了选择要关闭计时器
                this.waitChooseTime.Stop();
                this.enableJudge = false;
                //关闭两个图片
                this.imageBox1.Visible = false;
                this.imageBox2.Visible = false;
                if (this.currentShowType == ShowType.PERSON_AND_PERSON || this.currentShowType == ShowType.THING_AND_PERSON)
                {
                    //if (this.testSwitch)
                    //{
                        saveResult(0, 0);
                    //}
                }
                if (this.currentShowType == ShowType.PERSON_AND_THING || this.currentShowType == ShowType.THING_AND_THING)
                {
                    //if (this.testSwitch)
                    //{
                        saveResult(1, 0);
                    //}
                }
                // 关闭第二个imageBox
                //this.imageBox2.Visible = false;
                if (this.testSwitch == false)
                {
                    this.showCurrentResult();
                }
                else
                {
                    // 继续显示焦点
                    this.showFocusPoint();
                }    
            }
            // 选择物体
            if (e.KeyCode == Keys.Right && this.enableJudge)
            {
                //做出了选择要关闭计时器
                this.waitChooseTime.Stop();
                this.enableJudge = false;
                //关闭两个图片
                this.imageBox1.Visible = false;
                this.imageBox2.Visible = false;
                // 选择物体，选择index为1
                if (this.currentShowType == ShowType.PERSON_AND_PERSON || this.currentShowType == ShowType.THING_AND_PERSON)
                {
                    //if (this.testSwitch)
                    //{
                        saveResult(0, 1);
                    //}
                }
                if (this.currentShowType == ShowType.PERSON_AND_THING || this.currentShowType == ShowType.THING_AND_THING)
                {
                    //if (this.testSwitch)
                    //{
                        saveResult(1, 1);
                    //}
                }
                // 关闭第二个imageBox
                //this.imageBox2.Visible = false;
                if (this.testSwitch == false)
                {
                    this.showCurrentResult();
                }
                else
                {
                    // 继续显示焦点
                    this.showFocusPoint();
                }
            }
        }

        // 图片展示处理
        private void getShowImageType()
        {
            //选择显示方式
            this.currentShowType = randStatusContainer.getShowType();
            //要显示的图片的地址
            this.currentShowImages = randImages(this.currentShowType);
            this.currentDisappearType = randStatusContainer.getDisappearType();
            this.currentSecondImagePoint = randStatusContainer.getSecondImagePoint(this.currentDisappearType);
            this.secondImageIndex = randStatusContainer.currentPosition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="showType"></param>
        /// <returns>返回两张图片的数组</returns>
        private List<String> randImages(ShowType showType)
        {
            List<String> imagesPath = new List<String>(2);

            switch (showType)
            {
                case ShowType.PERSON_AND_PERSON:
                    imagesPath.Add(randSelectImage(group1Images));
                    imagesPath.Add(randSelectImage(group1Images));
                    break;

                case ShowType.PERSON_AND_THING:
                    imagesPath.Add(randSelectImage(group1Images));
                    imagesPath.Add(randSelectImage(group2Images));
                    break;

                case ShowType.THING_AND_PERSON:
                    imagesPath.Add(randSelectImage(group2Images));
                    imagesPath.Add(randSelectImage(group1Images));
                    break;

                case ShowType.THING_AND_THING:
                    imagesPath.Add(randSelectImage(group2Images));
                    imagesPath.Add(randSelectImage(group2Images));
                    break;

                default:
                    break;
            }
            return imagesPath;
        }

        private String randSelectImage(List<String> groupImages)
        {
            int randIndex = this.randImage(groupImages);
            String imagePath = groupImages[randIndex];
            groupImages.RemoveAt(randIndex);
            return imagePath;
        }

        /// <summary>
        /// 由展示焦点计时器来进行调用
        /// 按照不同的消失方式来展示图片
        /// </summary>
        private void showImages() {
            imageBox1.Load(currentShowImages[0]);
            currentNum += 1;
            //状态栏显示第几组
            this.Index.Text = String.Format("第{0}组", this.currentNum);
            timer1.Enabled = true;
            timer1.Start();
            }

        /// <summary>
        /// 等待3s触发，直接不等待选择进入下一组图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void waitChooseTime_Tick(object sender, EventArgs e)
        {
            //关闭当前的计时器
            this.waitChooseTime.Stop();
            this.enableJudge = false;
            //关闭两个图片
            this.imageBox1.Visible = false;
            this.imageBox2.Visible = false;
            Result result = allResult[this.currentNum - 1];
            result.setType(this.currentShowType, this.currentDisappearType, this.secondImageIndex);
            if (!this.testSwitch)
            {
                this.showCurrentResult();
            }
            else {
                // 继续显示焦点
                this.showFocusPoint();
            }

            
        }

        //显示当前的结果
        private void showCurrentResult() {
            //将label置中
            this.trainResultLabel.Location = this.trainResultLabelPoint;
            // 显示当前结果
            Result result = this.allResult[this.currentNum - 1];
            StringBuilder showResult = new StringBuilder();
            if(result.chooseIfCorrent==null)
            {
                showResult.Append("请在3S内做出反应；");
            }
            else{
            showResult.Append(result.chooseIfCorrent.Value?"正确；":"错误；");
                showResult.Append(result.usedTime+" ms");
            }
            this.trainResultLabel.Text = showResult.ToString();
            this.trainResultLabel.Visible = true;
            //计时1s
            this.resultTimer.Enabled = true;
            this.resultTimer.Start();
        }

        private void resultTimer_Tick(object sender, EventArgs e)
        {
            this.resultTimer.Stop();
            this.trainResultLabel.Visible = false;
            // 继续显示焦点
            this.showFocusPoint();
        }

    }
}
