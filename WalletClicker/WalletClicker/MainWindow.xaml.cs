using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WalletClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool powerFlag = false;

        public Profile profile = new Profile();
        public static List<string> wallets = new List<string>();
        public string previousWallet = string.Empty;

        public List<Task> tasks = new List<Task>();
        ChromeOptions options = new ChromeOptions();

        enum WorkStatus
        {
            Работае,
            Выключено
        }

        public MainWindow()
        {
            InitializeComponent();

            StreamReader walletsReader = new StreamReader("wallets.txt");

            workStatus.Content = WorkStatus.Выключено.ToString();

            string line = string.Empty;
            while ((line = walletsReader.ReadLine()) != null)
            {
                wallets.Add(line);
            }

            usernameL.Content = $"(Default: {Environment.UserName})";
        }

        private void ChangeFlag()
        {
            if (powerFlag == false)
            {
                powerFlag = true;
                workStatus.Content = WorkStatus.Работае.ToString();
            }
            else
            {
                powerFlag = false;
                workStatus.Content = WorkStatus.Выключено.ToString();
            }
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Имя пользователя можно найти по следующему пути:\nC:\\Users", "ПОМОЩЬ", MessageBoxButton.OK);
        }

        private void pullBtn_Click(object sender, RoutedEventArgs e)
        {
            StreamReader profileReader = new StreamReader("profile.txt");

            List<TextBox> textBoxes = new List<TextBox>
            {
                metaNum, metaPass, trustNum, trustPass, profileName
            };

            string line = string.Empty;
            int i = 0;
            while ((line = profileReader.ReadLine()) != null)
            {
                textBoxes[i].Text = line;
                i++;
            }

            profileReader.Close();
            profileReader.Dispose();
            textBoxes = null;
        }

        private void pushBtn_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter profileWriter = new StreamWriter("profile.txt", false);

            List<TextBox> textBoxes = new List<TextBox>
            {
                metaNum, metaPass, trustNum, trustPass, profileName
            };

            foreach (var item in textBoxes)
            {
                profileWriter.WriteLine(item.Text);
            }

            profileWriter.Close();
            profileWriter.Dispose();

            textBoxes = null;

            var result = MessageBox.Show("Данные сохранены!\nОткрыть файл?", "ИНФО", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                Process.Start("notepad.exe", "profile.txt");
        }

        private void metaNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (metaNum.Text != "" && metaPass.Text != "" && trustNum.Text != "" && trustNum.Text != "")
            {
                powerBtn.IsEnabled = true;
                pushBtn.IsEnabled = true;

            }
            else
            {
                powerBtn.IsEnabled = false;
                pushBtn.IsEnabled = false;


            }
        }

        private void metaPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (metaNum.Text != "" && metaPass.Text != "" && trustNum.Text != "" && trustNum.Text != "")
            {
                powerBtn.IsEnabled = true;
                pushBtn.IsEnabled = true;
            }
            else
            {
                powerBtn.IsEnabled = false;
                pushBtn.IsEnabled = false;

            }
        }

        private void trustNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (metaNum.Text != "" && metaPass.Text != "" && trustNum.Text != "" && trustNum.Text != "")
            {
                powerBtn.IsEnabled = true;
                pushBtn.IsEnabled = true;

            }
            else
            {
                powerBtn.IsEnabled = false;
                pushBtn.IsEnabled = false;
            }
        }

        private void trustPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (metaNum.Text != "" && metaPass.Text != "" && trustNum.Text != "" && trustNum.Text != "")
            {
                powerBtn.IsEnabled = true;
                pushBtn.IsEnabled = true;
            }
            else
            {
                powerBtn.IsEnabled = false;
                pushBtn.IsEnabled = false;
            }
        }

        private void profileName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (metaNum.Text != "" && metaPass.Text != "" && trustNum.Text != "" && trustNum.Text != "")
            {
                powerBtn.IsEnabled = true;
                pushBtn.IsEnabled = true;
            }
            else
            {
                powerBtn.IsEnabled = false;
                pushBtn.IsEnabled = false;

            }
        }

        public void Trust(ChromeDriver driver)
        {
            try
            {
                driver.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
                Thread.Sleep(400);
                driver.SwitchTo().Window(driver.WindowHandles[0]);
                Thread.Sleep(400);
                driver.FindElement(By.XPath("html/body/div/div[1]/div[3]/div/ul/div[1]/div")).Click();//клик на вбт
                Thread.Sleep(500);

                driver.FindElement(By.XPath("html/body/div/div[2]/div[1]/div[2]/div[2]/button[1]")).Click();//сенд
                Thread.Sleep(500);

                var walletText = driver.FindElement(By.XPath("html/body/div/div[2]/div/div/div[1]/div[4]/input"));//поле с адресом

                Random r = new Random();

                string wallet = wallets[r.Next(0, wallets.Count)];

                while (wallet == previousWallet)
                {
                    wallet = wallets[r.Next(0, wallets.Count)];
                }

                if (string.IsNullOrEmpty(wallet))
                    wallet = wallets[r.Next(0, wallets.Count)];

                previousWallet = wallet;

                Thread.Sleep(800);
                walletText.SendKeys(wallet);
                Thread.Sleep(800);

                var WBTAmount = driver.FindElement(By.XPath("html/body/div/div[2]/div/div/div[1]/div[6]/div[1]/input"));//поле с количеством
                WBTAmount.SendKeys("1");
                Thread.Sleep(500);

                try
                {
                    driver.FindElement(By.XPath("/html/body/div/div[2]/div/div/div[1]/div[6]/div[1]/div"));
                    Thread.Sleep(1000);
                    driver.Navigate().GoToUrl("chrome-extension://egjidjbpglichdcondbcbdnbeeppgdph/home.html#/");
                    
                }
                catch (Exception)
                {
                    Thread.Sleep(1000);
                    var receipt = driver.FindElement(By.XPath("/html/body/div/div[3]"));
                    receipt.Click();
                    Thread.Sleep(1000);

                    var confirm = driver.FindElement(By.XPath("/html/body/div/div[3]"));//конфирм
                    confirm.Click();
                    Thread.Sleep(4000);

                    var rollback = driver.FindElement(By.XPath("html/body/div/div[3]/div/label[1]/div"));//возврат на кошелек
                    rollback.Click();
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                driver.Navigate().GoToUrl("chrome-extension://egjidjbpglichdcondbcbdnbeeppgdph/home.html#/");
            }
            finally
            {
                Thread.Sleep(300);
            }
        }

        private void Mask(ChromeDriver driver)
        {
            try
            {
                driver.Navigate().GoToUrl("chrome-extension://egjidjbpglichdcondbcbdnbeeppgdph/home.html#/");
                Thread.Sleep(1100);
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                Thread.Sleep(1900);

                var sendButton = driver.FindElement(By.XPath("html/body/div[1]/div/div[3]/div/div/div[1]/div[2]/div/div[2]/button[2]"));

                sendButton.Click();

                Thread.Sleep(800);

                var walletInput = driver.FindElement(By.XPath("html/body/div[1]/div/div[3]/div/div[2]/div/input"));

                Random r = new Random();

                string wallet = wallets[r.Next(0, wallets.Count)];

                while (wallet == previousWallet)
                {
                    wallet = wallets[r.Next(0, wallets.Count)];
                }

                if (string.IsNullOrEmpty(wallet))
                    wallet = wallets[r.Next(0, wallets.Count)];

                previousWallet = wallet;

                Thread.Sleep(1000);
                walletInput.SendKeys(wallet);

                #region Send_NSV
                Thread.Sleep(800);

                driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div/div[3]/div/div[1]/div[2]/div/div/div/div[2]/div[1]")).Click();
                Thread.Sleep(800);
                driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div/div[3]/div/div[1]/div[2]/div/div[2]/div[2]/div[2]/div[2]/div[1]")).Click();

                Thread.Sleep(800);
                #endregion

                var amountWBT = driver.FindElement(By.XPath("html/body/div[1]/div/div[3]/div/div[3]/div/div[2]/div[2]/div[1]/div/div/div[1]/input"));
                amountWBT.SendKeys("1");

                Thread.Sleep(900);

                try
                {
                    driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div/div[3]/div/div[2]/div[2]/div[2]/div"));
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div/div[4]/footer/button[1]")).Click();
                }
                catch (Exception)
                {
                    driver.FindElement(By.XPath("html/body/div[1]/div/div[3]/div/div[4]/footer/button[2]")).Click();
                    Thread.Sleep(2600);
                    driver.FindElement(By.XPath("html/body/div[1]/div/div[3]/div/div[3]/div[3]/footer/button[2]")).Click();
                    Thread.Sleep(700);
                }
            }
            catch (Exception)
            {
                driver.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#");
            }
            finally
            {
                Thread.Sleep(300);
            }
        }


        private Task StartBrowserWithWallets(ref ChromeDriver driver)
        {
            try
            {
                double seconds = DateTime.Now.TimeOfDay.TotalSeconds;
                OpenWallets(ref driver);
                DoWalletWork(ref driver, ref seconds);
            }
            catch(Exception ex)
            {
                driver.Dispose();
                KillChrome();
                ChromeDriver driver1 = new ChromeDriver(options);
                StartBrowserWithWallets(ref driver1);
            }
            driver.Dispose();
            return Task.CompletedTask;
        }

        private void OpenWallets(ref ChromeDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(1200);
            driver.Navigate().GoToUrl("chrome-extension://egjidjbpglichdcondbcbdnbeeppgdph/home.html#/"); // trust
            Thread.Sleep(3000);
            var fieldTrust = driver.FindElement(By.XPath("html/body/div/div/div/form/div[5]/div/div/input"));
            Thread.Sleep(1000);
            fieldTrust.SendKeys(profile.walletTrustPass);
            Thread.Sleep(600);
            driver.FindElement(By.XPath("/html/body/div/div/div/form/button")).Click();
            Thread.Sleep(1000);

            driver.SwitchTo().NewWindow(WindowType.Tab);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Thread.Sleep(200);
            driver.Navigate().GoToUrl("chrome-extension://nkbihfbeogaeaoehlefnkodbefgpgknn/home.html#"); // metamask
            Thread.Sleep(1000);
            var fieldMeta = driver.FindElement(By.XPath("html/body/div[1]/div/div[3]/div/div/form/div/div/input"));
            Thread.Sleep(600);
            fieldMeta.SendKeys(profile.walletMetaPass);
            Thread.Sleep(600);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div/div/button")).Click();
            Thread.Sleep(200);
        }

        private void DoWalletWork(ref ChromeDriver driver, ref double seconds)
        {
            while (powerFlag)
            {
                if ((DateTime.Now.TimeOfDay.TotalSeconds - seconds) < 180)
                {
                    Trust(driver);
                    Mask(driver);
                }
                else
                {
                    driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/button/div")).Click();
                    Thread.Sleep(600);
                    driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[2]/button")).Click();
                    Thread.Sleep(600);
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    driver.FindElement(By.XPath("/html/body/div/div[2]/div/label[3]/div")).Click();
                    Thread.Sleep(600);
                    driver.FindElement(By.XPath("/html/body/div/div[2]/div/div/button[12]/div[2]/div")).Click();
                    ((IJavaScriptExecutor)driver).ExecuteScript("window.open('https://www.google.com','_blank');");
                    Thread.Sleep(500);
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    driver.Close();
                    Thread.Sleep(500);
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    driver.Close();
                    Thread.Sleep(500);
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    StartBrowserWithWallets(ref driver);
                    seconds = DateTime.Now.TimeOfDay.TotalSeconds;
                    Thread.Sleep(1000);
                }
            }
            driver.Dispose();
        }

        private void SetProfile()
        {
            profile.walletMetaNumber = metaNum.Text;
            profile.walletTrustNumber = trustNum.Text;
            profile.walletMetaPass = metaPass.Text;
            profile.walletTrustPass = trustPass.Text;
            profile.ProfileName = string.IsNullOrEmpty(profileName.Text) ? Environment.UserName : profileName.Text;
        }

        private void powerBtn_Click(object sender, RoutedEventArgs e) // MAIN()
        {
            if (!powerFlag)
            {
                SetProfile();
                ChangeFlag();

                options.AddArgument(@$"--user-data-dir=C:\Users\{(string.IsNullOrEmpty(profileName.Text) ? Environment.UserName : profileName.Text)}\AppData\Local\Google\Chrome\User Data");
                options.AddArgument("--profile-directory=Default");

                ChromeDriver driver = new ChromeDriver(options);
                Thread.Sleep(1000);

                try
                {
                    wallets.Remove(metaNum.Text);
                    wallets.Remove(trustNum.Text);

                    Task tusk = Task.Run(() => { StartBrowserWithWallets(ref driver); });
                    tasks.Add(tusk);


                }
                catch (Exception ex)
                {
                    Thread.Sleep(1500);
                    KillChrome();
                    Thread.Sleep(800);
                    driver.Dispose();
                    ChromeDriver driver1 = new ChromeDriver(options);
                    StartBrowserWithWallets(ref driver1);
                }
            }
            else
            {
                if (MessageBox.Show("Остановить прогу?", "ВНИМАНИЕ", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ChangeFlag();
                        MessageBox.Show("Прога вырубается.\nМож закрыть це окно", "ВНИМАНИЕ", MessageBoxButton.OK);
                        Task.WaitAll(tasks.ToArray());
                        KillChrome();


                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message;
                    }
                }
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", "wallets.txt");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1. Если прога вырубилась в самом начале\n" +
                "попробуй сам указать юзернейм\n" +
                "2. Юзернейм сам подбирается в системе, его необязательно указывать\n" +
                "3. Перед запуском закрывай Chrome и на всякий все вкладки\n" +
                "4. Перед запуском выйди на главную во всех кошелях", "ЧИТАЙ");
        }

        private void KillChrome()
        {
            Process[] localByName = Process.GetProcessesByName("chrome");
            foreach (Process p in localByName)
            {
                p.Kill();
            }
        }
    }
}
