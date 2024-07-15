using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.IO;
namespace SeleniumCsharp

{

    public class Tests

    {
        //homepage/navbar
        string NavBar = "//nav[contains(@data-t, 'navbar')]";
        string menuItemcount = "//div[3]//li";
        string NavBarSelect1 = "//nav[contains(@data-t, 'navbar')]//li//a[(text()='";


        //generic for stock pages
        string StockPototFirstAvailable = "//div[contains(@data-t, 'search-result-cell')]";
        string H5FindText = "//h5[contains(., '";
        string SpanFindText = "//span[contains(., '";
        string FindTextClose = "')]";
        string ClosingHalfForText = "']";
        string StrongFindText = "//strong[contains(., '";
        string H3FindText = "//h3[contains(., '";
        string NumberOfResults = "//strong[contains(@class,'text-sregular grey gravel-text')]";
        string LIFindText = "//li[contains(., '";
        string inputFindByValue = "//input[contains(@value,'";


        //photo page
        string PopularStockImageryBar = "//ul[contains(@data-t, 'section5-KeywordCarousel-slider-list')]//li";
        string photoList = "//ul[contains(@data-t,'section7-CategoryCardGroup-section')]//picture//img";
        string StockPhotoCategories = "//ul[contains(@data-t, 'section7-CategoryCardGroup-section')]//li";
        string SPCNature = "[contains(.,'Nature')]";
        string SPCImageSelection1 = "//ul[contains(@class, 'sc-kpOJdX sc-ckVGcZ dFBTRG')]//p[text() = '";
        string SPCClickFirstItem = "//div[contains(@data-t, 'group-card-2-image-wrapper')]";


        //Illistrations page
        string NavBarFindByText = "//a[(text()='";
        string IllistrationsItems = "//ul[contains(@data-t, 'section6-CardGroup-section')]//h3";
        string IllistrationsItemsText = "//ul[contains(@data-t, 'section6-CardGroup-section')]//h3[text() = '";


        //vector page
        string GroupToSeeOnPages = "//ul[contains(@data-t, 'section6-CardGroup-section')]//li";
        string CardGroupTitle = "//h3[contains(@data-t, 'section6-CardGroup-card-1-title')]";
        string SearchResultdiv1 = "//div[@id='search-results']/div[1]";

        //videos
        string VideoCatagoryes = "//div[contains(@data-t, 'section5-KeywordCarousel-slider')]//p[text() = '";
        string VideoItemsFound = "//ul[contains(@data-t, 'section7-VideoCardGroup-section')]//li";
        string VideoSelectItem = "//video[contains(@data-t, 'section7-VideoCardGroup-card-1-video')]";

        //Audio page
        string ItemsFoundSecondGroup = "//ul[contains(@data-t, 'section9-CardGroup-section')]//li";
        string AudioPlayButton = "//button[contains(@data-t,'audio-player-0-button-play')]";
        string AudioDurations = "//div[contains(@data-t,'audio-player-0-duration-text')]";
        string AudioBPM = "//div[contains(@data-t,'audio-player-0-bpm-text')]";
        string AudioMoreOption = "//button[contains(@aria-label,'More options')]";
        string AudioSaveToLibrary = "//button[contains(@aria-label,'Save to library')]";
        string AudioDownloadPreview = "//button[contains(@aria-label,'Download Preview')]";
        string AudioFreeWithTrial = "//button[contains(@aria-label,'Free with trial')]";
        string AudioViewPanel = "//button[contains(@data-t,'toggle-filters-panel')]";
        string AudioNumberOfResultsFound = "//span[contains(@data-t,'audio-results-count-text')]";
        string InputFindByName = "//input[contains(@name,'";

        //temlets//free//FFonts//Plugins//3D
        string DivClassGroup = "//div[contains(@class,'detail-button-group')]";
        string buttonFindText = "//button[contains(., '";
        string filterSection = "//fieldset[contains(@data-t,'asset-type-filter-section')]";
        string labelFindText = "//label[contains(., '";
        string PluginsmenuItem = "//div[contains(@style,'flex-direction: column; align-items: stretch;')]//div[contains(@role,'region')]";
        string PluginResults = "//p[contains(@data-launchid,'total results')]";
        string Panal3DSubcategory = "//fieldset[contains(@data-t, 'price-filter-section')]";
        string AS2DTotalResults = "//h1[contains(@class,'no-margin container-inline')]";
        string AS3DRows = "//div[contains(@class,'row with-gutter')]";
        string aFindText = "//a[contains(., '";
        string pFindText = "//p[contains(., '";
        string SideBarText = "//div[contains(@data-testid,'browse-sidebar-checkboxes-product')]//label//span[text()]";
        string TemplatesSideBarText = "//span[contains(@data-t,'templates-type-asset-subcategory-filter-section')]//label[text()]";
       


        private IWebDriver driver;

        [SetUp]
        public void StartTest()
        {
            // Get the parent directory of the current directory
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            // Create the ChromeDriver object and execute tests on Google Chrome
            driver = new ChromeDriver(path + @"\drivers\");

            // Set the implicit wait time to 2 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }


        [Test]
        public void navigatetosite()
        {
            // Navigating to the website
            driver.Navigate().GoToUrl("https://stock.adobe.com/");

            // Asserting that the navigation bar is displayed
            Assert.IsTrue(driver.FindElement(By.XPath(NavBar)).Displayed);
        }


        // This method verifies the count of menu items on the website.
        [Test]
        public void verifyMenuItemcount()
        {
            // Navigating to the website
            driver.Navigate().GoToUrl("https://stock.adobe.com/");

            // Waiting for 2 seconds to ensure the page is fully loaded
            Thread.Sleep(2000);

            // Finding all the menu items using the specified XPath
            ReadOnlyCollection<IWebElement> menuItem = driver.FindElements(By.XPath(menuItemcount));

            // Verifying that the count of menu items is equal to 11
            Assert.AreEqual(menuItem.Count, 11);
        }


        // The "navigateToPhotosTab" test method navigates to a website, clicks on the "Photos" tab in the navigation bar, verifies the number of menu items and items found,
        // selects a category in the stock photo categories, verifies the presence of specific image selections, clicks on the first item in the stock photo selection,
        // waits for the page to load, clicks on the first available stock photo, and verifies the presence of specific text elements.       
        [Test]
        public void navigateToPhotosTab()
        {
            // Navigating to the website
            driver.Navigate().GoToUrl("https://stock.adobe.com/");

            // Adding a delay for the page to load
            Thread.Sleep(1000);

            // Clicking on the "Photos" tab in the navigation bar
            driver.FindElement(By.XPath(NavBarFindByText + "Photos" + FindTextClose)).Click();

            // Verifying the number of menu items
            ReadOnlyCollection<IWebElement> menuItem = driver.FindElements(By.XPath(PopularStockImageryBar));
            Assert.AreEqual(menuItem.Count, 10);

            // Verifying the number of items found
            ReadOnlyCollection<IWebElement> itemsfound = driver.FindElements(By.XPath(photoList));
            Assert.AreEqual(itemsfound.Count, 12);

            // Clicking on the "Nature" category in the stock photo categories
            driver.FindElement(By.XPath(StockPhotoCategories + SPCNature)).Click();

            // Verifying the presence of specific image selections
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SPCImageSelection1 + "Sunset" + ClosingHalfForText)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SPCImageSelection1 + "Star" + ClosingHalfForText)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SPCImageSelection1 + "Forest" + ClosingHalfForText)));

            // Clicking on the first item in the stock photo selection
            driver.FindElement(By.XPath(SPCClickFirstItem)).Click();

            // Adding a delay for the page to load
            Thread.Sleep(1000);

            // Clicking on the first available stock photo
            driver.FindElement(By.XPath(StockPototFirstAvailable)).Click();

            // Adding a delay for the page to load
            Thread.Sleep(1000);

            // Verifying the presence of specific text elements
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Dimensions" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "File Type" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Category" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "License Type" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Standard license" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Extended license" + FindTextClose)));


            // Additional comments can be added here if needed
        }


        // This method navigates to the "Illustrations" tab on the website, performs various assertions, and interacts with elements on the page.
        [Test]
        public void navigateToIllustrationsTab()
        {
            // Navigating to the website
            driver.Navigate().GoToUrl("https://stock.adobe.com/");

            // Clicking on the "Illustrations" tab in the navigation bar
            driver.FindElement(By.XPath(NavBarFindByText + "Illustrations" + FindTextClose)).Click();
            Thread.Sleep(1000);

            // Finding all the items on the page
            ReadOnlyCollection<IWebElement> itemsfound = driver.FindElements(By.XPath(IllistrationsItems));

            // Asserting that the number of items found is equal to 6
            Assert.AreEqual(itemsfound.Count, 6);

            // Asserting that specific items are not empty
            Assert.IsNotEmpty(driver.FindElements(By.XPath(IllistrationsItemsText + "Digital renders" + ClosingHalfForText)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(IllistrationsItemsText + "Paintings" + ClosingHalfForText)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(IllistrationsItemsText + "Cartoons" + ClosingHalfForText)));

            // Clicking on the "Digital renders" item
            driver.FindElement(By.XPath(IllistrationsItemsText + "Digital renders" + ClosingHalfForText)).Click();
            Thread.Sleep(1000);

            // Clicking on the first available stock photo
            driver.FindElement(By.XPath(StockPototFirstAvailable)).Click();
            Thread.Sleep(1000);

            // Asserting that specific elements are not empty
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Dimensions" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "File Type" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Category" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "License Type" + FindTextClose)));

            // Asserting that specific license types are not empty
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Standard license" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Extended license" + FindTextClose)));

            // TODO: Test the side bar here
        }


        // The code navigates to the "Vectors" tab on the website, performs various assertions, and checks the radio type for the inputs on the page.
        // It uses Selenium WebDriver to interact with the web elements.
        [Test]
        public void navigateToVectorsTab()
        {
            // Navigating to the website
            driver.Navigate().GoToUrl("https://stock.adobe.com/");

            // Clicking on the "Vectors" tab in the navigation bar
            driver.FindElement(By.XPath(NavBarFindByText + "Vectors" + FindTextClose)).Click();

            // Finding the items on the page
            ReadOnlyCollection<IWebElement> itemsfound = driver.FindElements(By.XPath(GroupToSeeOnPages));

            // Asserting that the number of items found is equal to 4
            Assert.AreEqual(itemsfound.Count, 4);

            // Asserting that the card group title is not empty
            Assert.IsNotEmpty(driver.FindElements(By.XPath(CardGroupTitle)));

            // Clicking on the "New tech vector art" heading
            driver.FindElement(By.XPath(H3FindText + "New tech vector art" + FindTextClose)).Click();

            // Adding a delay to allow the page to load
            Thread.Sleep(1000);

            // Clicking on the first search result
            driver.FindElement(By.XPath(SearchResultdiv1)).Click();

            // Adding a delay to allow the page to load
            Thread.Sleep(1000);

            // Asserting that certain elements are not empty
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "File Type" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Category" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "License Type" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Standard license" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Extended license" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Save to Library" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Download Preview" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Preview Crop" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Find Similar" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(StrongFindText + "File #:" + FindTextClose)));

            // TODO: Add code to check the radio type for the inputs on this page
        }


        // This method navigates to the "Videos" tab on the website, performs various assertions and actions,
        // and can be used for testing the functionality of the videos tab.
        [Test]
        public void navigateTovideosTab()
        {
            // Navigating to the website
            driver.Navigate().GoToUrl("https://stock.adobe.com/");

            // Clicking on the "Videos" tab in the navigation bar
            driver.FindElement(By.XPath(NavBarFindByText + "Videos" + FindTextClose)).Click();

            // Asserting that there are non-empty elements for the specified video categories
            Assert.IsNotEmpty(driver.FindElements(By.XPath(pFindText + "Weather" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(pFindText + "Music" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(pFindText + "Animals" + FindTextClose)));

            // Finding the number of items found and asserting that it is equal to 8
            ReadOnlyCollection<IWebElement> itemsfound = driver.FindElements(By.XPath(VideoItemsFound));
            Assert.AreEqual(itemsfound.Count, 8);

            // Asserting that there is a non-empty element for the selected video item
            Assert.IsNotEmpty(driver.FindElements(By.XPath(VideoSelectItem)));

            // Clicking on the selected video item
            driver.FindElement(By.XPath(VideoSelectItem)).Click();

            // Adding a delay of 1 second for demonstration purposes
            Thread.Sleep(1000);

            // Clicking on the search result div
            driver.FindElement(By.XPath(SearchResultdiv1)).Click();

            // Adding a delay of 1 second for demonstration purposes
            Thread.Sleep(1000);

            // Asserting that there are non-empty elements for the specified video details
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Dimensions" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "File Type" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Codec" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Bit Rate" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Duration" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Frame Rate" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "File Size" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Category" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "License Type" + FindTextClose)));

            // Asserting that there are non-empty elements for the specified video options
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "HD" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "4K" + FindTextClose)));

            // Asserting that there is a non-empty element for the "Download free with trial" option
            Assert.IsNotEmpty(driver.FindElements(By.XPath("//span[contains(., 'Download free with trial')]")));

            // Asserting that there are non-empty elements for the specified video actions
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Save to Library" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Download HD Preview" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Find Similar" + FindTextClose)));

            // Asserting that there is a non-empty element for the "File #:" label
            Assert.IsNotEmpty(driver.FindElements(By.XPath(StrongFindText + "File #:" + FindTextClose)));

            // Perform some kind of test or action here
        }


        // The code in the navigateToAudioTab() method navigates to the website, clicks on the "Audio" tab in the navigation bar,
        // finds and asserts the count of items on the page, clicks on specific elements, asserts that certain elements are not empty,
        // clicks on the "View Panel" button, stores the baseline number of results, clicks on different filter options, and asserts that
        // the number of results has changed or returned to the baseline.
        [Test]
        public void navigateToAudioTab()
        {
            // Navigating to the website
            driver.Navigate().GoToUrl("https://stock.adobe.com/");

            // Clicking on the "Audio" tab in the navigation bar
            driver.FindElement(By.XPath(NavBarFindByText + "Audio" + FindTextClose)).Click();

            // Finding the items on the page and asserting the count
            ReadOnlyCollection<IWebElement> itemsfound = driver.FindElements(By.XPath(GroupToSeeOnPages));
            Assert.AreEqual(itemsfound.Count, 3);

            // Finding the items in the second group and asserting the count
            ReadOnlyCollection<IWebElement> itemsfound2 = driver.FindElements(By.XPath(ItemsFoundSecondGroup));
            Assert.AreEqual(itemsfound2.Count, 3);

            // Asserting that specific elements are not empty
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H3FindText + "Electronica" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H3FindText + "Pop" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H3FindText + "Film" + FindTextClose)));

            // Clicking on the "Electronica" item
            driver.FindElement(By.XPath(H3FindText + "Electronica" + FindTextClose)).Click();

            // Asserting that specific elements are not empty
            Assert.IsNotEmpty(driver.FindElements(By.XPath(AudioPlayButton)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath("//wave")));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(AudioDurations)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(AudioBPM)));

            // Asserting that specific elements are not empty
            Assert.IsNotEmpty(driver.FindElements(By.XPath(AudioMoreOption)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(AudioSaveToLibrary)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(AudioDownloadPreview)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(AudioFreeWithTrial)));

            // Clicking on the "View Panel" button
            driver.FindElement(By.XPath(AudioViewPanel)).Click();

            // Storing the baseline number of results
            var Baceline = driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text;

            // Clicking on the "LOOP" input
            driver.FindElement(By.XPath(InputFindByName + "LOOP" + FindTextClose)).Click();
            Thread.Sleep(1000);           

            // Asserting that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            // Clicking on the "LOOP" input again
            driver.FindElement(By.XPath(InputFindByName + "LOOP" + FindTextClose)).Click();
            //Thread.Sleep(1000);

            // Asserting that the number of results has returned to the baseline
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            // Clicking on different filter options and asserting that the number of results has changed
            driver.FindElement(By.XPath(inputFindByValue + "has-vocals" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            driver.FindElement(By.XPath(inputFindByValue + "has-vocals" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            driver.FindElement(By.XPath(inputFindByValue + "no-vocal" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            driver.FindElement(By.XPath(inputFindByValue + "no-vocal" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            driver.FindElement(By.XPath(inputFindByValue + "Epidemic Sound" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            driver.FindElement(By.XPath(inputFindByValue + "Epidemic Sound" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            driver.FindElement(By.XPath(inputFindByValue + "FineTune Music" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            driver.FindElement(By.XPath(inputFindByValue + "FineTune Music" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            driver.FindElement(By.XPath(inputFindByValue + "Jamendo" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            driver.FindElement(By.XPath(inputFindByValue + "Jamendo" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            driver.FindElement(By.XPath(inputFindByValue + "Keyframe Audio" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            driver.FindElement(By.XPath(inputFindByValue + "Keyframe Audio" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            driver.FindElement(By.XPath(inputFindByValue + "Music Revolution" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);

            driver.FindElement(By.XPath(inputFindByValue + "Music Revolution" + FindTextClose)).Click();
            Thread.Sleep(1000);
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(AudioNumberOfResultsFound)).Text);
        }


        // This code navigates to the "Templates" tab on the website, performs various actions, and asserts the expected results.
        // It verifies the number of items found, clicks on different labels, waits for specified durations, and asserts that certain elements are not empty.
        // It also checks if the number of results has changed after clicking on labels and asserts the expected results.
        // Overall, this code tests the functionality of navigating to the "Templates" tab and performing actions on the page.
        [Test]
        public void navigateToTemplatesTab()
        {
            // Navigating to the website
            driver.Navigate().GoToUrl("https://stock.adobe.com/");

            // Clicking on the "Templates" tab in the navigation bar
            driver.FindElement(By.XPath(NavBarFindByText + "Templates" + FindTextClose)).Click();

            // Finding the items on the page
            ReadOnlyCollection<IWebElement> itemsfound = driver.FindElements(By.XPath(GroupToSeeOnPages));

            // Asserting that the number of items found is equal to 4
            Assert.AreEqual(itemsfound.Count, 4);

            // Clicking on the "Photoshop templates" heading
            driver.FindElement(By.XPath(H3FindText + "Photoshop templates" + FindTextClose)).Click();

            // Waiting for 1 second
           Thread.Sleep(1000);

            // Clicking on the first search result
            driver.FindElement(By.XPath(SearchResultdiv1)).Click();

            // Waiting for 1 second
            Thread.Sleep(1000);

            // Asserting that certain elements are not empty
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "File Type" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "File Size" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Use With" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "License Type" + FindTextClose)));

            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Template details:" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(LIFindText + "RGB" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(LIFindText + "1 design option" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(LIFindText + "6000 x 4000 pixels" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(LIFindText + "Photos or design elements shown in the preview are for display only and are not included in the downloaded file" + FindTextClose)));

            Assert.IsNotEmpty(driver.FindElements(By.XPath(StrongFindText + "Photoshop Template" + FindTextClose)));

            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Save to Library" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "View Preview" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(StrongFindText + "File #:" + FindTextClose)));

            Assert.IsNotEmpty(driver.FindElements(By.XPath(DivClassGroup + SpanFindText + "Download free with trial" + FindTextClose)));

            // Waiting for 1 second
            Thread.Sleep(1000);

            // Storing the baseline number of results
            var Baceline = driver.FindElement(By.XPath(NumberOfResults)).Text;
            
            IList<IWebElement> all = driver.FindElements(By.XPath(TemplatesSideBarText));

            String[] allText = new String[all.Count];
            int i = 0;
            // int j = 0;
            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }

            for (int j = 2; j != i; j++)
            {
                driver.FindElement(By.XPath(labelFindText + allText[j] + FindTextClose)).Click();
                Thread.Sleep(5000);
                Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(PluginResults)).Text);
                driver.FindElement(By.XPath(labelFindText + allText[j] + FindTextClose)).Click();
                Thread.Sleep(1000);
            }

            /*

            // Clicking on the "Illustrator" label
            driver.FindElement(By.XPath(labelFindText + "Illustrator" + FindTextClose), 5).Click();
            // Waiting for 5 seconds
            Thread.Sleep(5000);

            // Asserting that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults), 5).Text);

            // Clicking on the "Illustrator" label again
            driver.FindElement(By.XPath(labelFindText + "Illustrator" + FindTextClose), 5).Click();
            // Waiting for 1 second
            Thread.Sleep(1000);

            // Asserting that the number of results is back to the baseline
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults), 5).Text);

            // Clicking on the "InDesign" label
            driver.FindElement(By.XPath(labelFindText + "InDesign" + FindTextClose), 5).Click();
            // Waiting for 4 seconds
            Thread.Sleep(4000);

            // Asserting that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults), 5).Text);

            // Clicking on the "InDesign" label again
            driver.FindElement(By.XPath(labelFindText + "InDesign" + FindTextClose), 5).Click();
            // Waiting for 1 second
            Thread.Sleep(1000);

            // Asserting that the number of results is back to the baseline
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults), 5).Text);

            // Clicking on the "Premiere Pro" label
            driver.FindElement(By.XPath(labelFindText + "Premiere Pro" + FindTextClose), 5).Click();
            // Waiting for 5 seconds
            Thread.Sleep(5000);

            // Asserting that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults), 5).Text);

            // Clicking on the "Premiere Pro" label again
            driver.FindElement(By.XPath(labelFindText + "Premiere Pro" + FindTextClose), 5).Click();
            // Waiting for 1 second
            Thread.Sleep(1000);

            // Asserting that the number of results is back to the baseline
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults), 5).Text);

            // Clicking on the "Premiere Rush" label
            driver.FindElement(By.XPath(labelFindText + "Premiere Rush" + FindTextClose), 5).Click();
            // Waiting for 5 seconds
            Thread.Sleep(5000);

            // Asserting that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults), 5).Text);

            // Clicking on the "Premiere Rush" label again
            driver.FindElement(By.XPath(labelFindText + "Premiere Rush" + FindTextClose), 5).Click();
            // Waiting for 1 second
            Thread.Sleep(1000);

            // Asserting that the number of results is back to the baseline
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults), 5).Text);

            // Clicking on the "After Effects" label
            driver.FindElement(By.XPath(labelFindText + "After Effects" + FindTextClose)).Click();
            // Waiting for 5 seconds
            Thread.Sleep(5000);

            // Asserting that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults)).Text);

            // Clicking on the "After Effects" label again
            driver.FindElement(By.XPath(labelFindText + "After Effects" + FindTextClose)).Click();
            // Waiting for 1 second
            Thread.Sleep(1000);

            // Asserting that the number of results is back to the baseline
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults)).Text);

            // Clicking on the "Undiscovered Content" label
            driver.FindElement(By.XPath(labelFindText + "Undiscovered Content" + FindTextClose)).Click();
            // Waiting for 5 seconds
            Thread.Sleep(5000);

            // Asserting that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults)).Text);

            // Clicking on the "Undiscovered Content" label again
            driver.FindElement(By.XPath(labelFindText + "Undiscovered Content" + FindTextClose)).Click();
            // Waiting for 1 second
            Thread.Sleep(1000);

            // Asserting that the number of results is back to the baseline
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults)).Text);

            // Clicking on the "Local Artists" label
            driver.FindElement(By.XPath(labelFindText + "Local Artists" + FindTextClose)).Click();
            // Waiting for 5 seconds
            Thread.Sleep(5000);

            // Asserting that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults)).Text);

            // Clicking on the "Local Artists" label again
            driver.FindElement(By.XPath(labelFindText + "Local Artists" + FindTextClose)).Click();
            // Waiting for 1 second
            Thread.Sleep(1000);

            // Asserting that the number of results is back to the baseline
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults)).Text);
            */
        }


        // This method navigates to the "Free" tab on the website, performs various actions, and asserts the results.
        [Test]
        public void navigateToFreeTab()
        {
            // Navigate to the website
            driver.Navigate().GoToUrl("https://stock.adobe.com/");

            // Click on the "Free" tab in the navigation bar
            driver.FindElement(By.XPath(NavBarFindByText + "Free" + FindTextClose)).Click();

            // Find the items on the page
            ReadOnlyCollection<IWebElement> itemsfound = driver.FindElements(By.XPath(GroupToSeeOnPages));

            // Assert that the number of items found is 3
            Assert.AreEqual(itemsfound.Count, 3);

            // Click on the "Free photos" heading
            driver.FindElement(By.XPath(H3FindText + "Free photos" + FindTextClose)).Click();

            // Wait for 2 seconds
            Thread.Sleep(2000);

            // Click on the first search result
            driver.FindElement(By.XPath(SearchResultdiv1)).Click();

            // Wait for 1 second
            Thread.Sleep(1000);

            // Assert that certain elements are not empty
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Dimensions" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "File Type" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(H5FindText + "Category" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "License Type" + FindTextClose)));

            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Download file type:" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(buttonFindText + "JPEG" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(buttonFindText + "PNG" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "License for Free" + FindTextClose)));

            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Save to Library" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Preview Crop" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(SpanFindText + "Find Similar" + FindTextClose)));
            Assert.IsNotEmpty(driver.FindElements(By.XPath(StrongFindText + "File #:" + FindTextClose)));

            // Get the baseline number of results
            var Baceline = driver.FindElement(By.XPath(NumberOfResults)).Text;

            // Click on the "Videos" filter
            driver.FindElement(By.XPath(filterSection + labelFindText + "Videos" + FindTextClose)).Click();
            Thread.Sleep(3000);

            // Assert that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults)).Text);

            // Update the baseline number of results
            Baceline = driver.FindElement(By.XPath(NumberOfResults)).Text;

            // Click on the "Templates" filter
            driver.FindElement(By.XPath(filterSection + labelFindText + "Templates" + FindTextClose)).Click();
            Thread.Sleep(3000);

            // Assert that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults)).Text);

            // Update the baseline number of results
            Baceline = driver.FindElement(By.XPath(NumberOfResults)).Text;

            // Click on the "3D" filter
            driver.FindElement(By.XPath(filterSection + labelFindText + "3D" + FindTextClose)).Click();
            Thread.Sleep(4000);

            // Assert that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults)).Text);

            // Update the baseline number of results
            Baceline = driver.FindElement(By.XPath(NumberOfResults)).Text;

            // Click on the "All" filter
            driver.FindElement(By.XPath(filterSection + labelFindText + "All" + FindTextClose)).Click();
            Thread.Sleep(4000);

            // Update the baseline number of results
            Baceline = driver.FindElement(By.XPath(NumberOfResults)).Text;

            // Click on the "Local Artists" filter
            driver.FindElement(By.XPath(labelFindText + "Local Artists" + FindTextClose)).Click();
            Thread.Sleep(4000);

            // Assert that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults)).Text);

            // Update the baseline number of results
            Baceline = driver.FindElement(By.XPath(NumberOfResults)).Text;

            // Click on the "Transparent" filter
            driver.FindElement(By.XPath(labelFindText + "Transparent" + FindTextClose)).Click();
            Thread.Sleep(4000);

            // Assert that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults)).Text);

            // Update the baseline number of results
            Baceline = driver.FindElement(By.XPath(NumberOfResults)).Text;

            // Click on the "Generative AI Only" filter
            driver.FindElement(By.XPath(labelFindText + "Generative AI Only" + FindTextClose)).Click();
            Thread.Sleep(4000);

            // Assert that the number of results has changed
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(NumberOfResults)).Text);
        }


        [Test]
        public void navigateToFontsTab()

        {
            driver.Navigate().GoToUrl("https://stock.adobe.com/");

            driver.FindElement(By.XPath(NavBarFindByText + "Fonts" + FindTextClose)).Click();

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            ReadOnlyCollection<IWebElement> itemsfound = driver.FindElements(By.XPath("//div[contains(@class, 'spectrum-grid-row')]"));
           
            Assert.AreEqual(itemsfound.Count, 19);

            // Adding a delay of 1 second for demonstration purposes
            Thread.Sleep(1000);

            //this will not work need to get one that will work 
            driver.FindElement(By.XPath("//af-specimen-carousel[contains(@id,'home-trending-fonts')]")).Click();

            //do some kind of thing to test things
            Assert.IsNotEmpty(driver.FindElements(By.XPath("//button[contains(.,'Fonts')]")));
            Assert.IsNotEmpty(driver.FindElements(By.XPath("//button[contains(.,'Recommendations')]")));
            Assert.IsNotEmpty(driver.FindElements(By.XPath("//button[contains(.,'About')]")));
            Assert.IsNotEmpty(driver.FindElements(By.XPath("//button[contains(.,'Licensing')]")));
            Assert.IsNotEmpty(driver.FindElements(By.XPath("//button[contains(.,'Details')]")));           

        }


        // This test method navigates to the "Plugins" tab on the website, performs a series of actions, and asserts the expected results.
        [Test]
        public void navigateToPluginsTab()
        {
            // Navigating to the website
            driver.Navigate().GoToUrl("https://stock.adobe.com/");

            // Clicking on the "Plugins" tab in the navigation bar
            driver.FindElement(By.XPath(NavBarFindByText + "Plugins" + FindTextClose)).Click();
            //Thread.Sleep(1000);

            // Switching to the new window
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Thread.Sleep(1000);

            // Finding all the menu items
            ReadOnlyCollection<IWebElement> menuItem = driver.FindElements(By.XPath(PluginsmenuItem));

            // Asserting that the plugin results are not empty
            Assert.IsNotEmpty(driver.FindElements(By.XPath(PluginResults)));

            // Asserting that the number of menu items is equal to 12
            Assert.AreEqual(12, menuItem.Count);

            // Storing the baseline text
            var Baceline = driver.FindElement(By.XPath(PluginResults)).Text;


            IList<IWebElement> all = driver.FindElements(By.XPath(SideBarText));

            String[] allText = new String[all.Count];
            int i = 0;
           // int j = 0;
            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }

            for (int j = 0; j != i; j++) 
            {
                driver.FindElement(By.XPath(labelFindText + allText[j] + FindTextClose)).Click();
                Thread.Sleep(5000);
                Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(PluginResults)).Text);
                driver.FindElement(By.XPath(labelFindText + allText[j] + FindTextClose)).Click();
                Thread.Sleep(1000);
            }
                   

            // Clicking on specific plugin labels and asserting that the results have changed

            
        }


        // This code is a test method named "navigateTo3DTab" that navigates to the 3D tab on the Adobe Stock website using Selenium WebDriver.
        // It performs a series of actions such as clicking on elements, asserting values, and updating baseline values.
        // The purpose of this test is to verify the functionality of the 3D section on the website.
        [Test]
        public void navigateTo3DTab()
        {
            // did not start this part need to work on this
            //driver.FindElement(By.XPath("//div[contains(@class, 'sc-kEmuub bYIRJi')]//li//a[(text()='3D')]")).Click();
            driver.Navigate().GoToUrl("https://stock.adobe.com/");

            // Click on the "3D" option in the navigation bar
            driver.FindElement(By.XPath(NavBarFindByText + "3D" + FindTextClose)).Click();

            // Find all the items in the 3D section
            ReadOnlyCollection<IWebElement> itemsfound = driver.FindElements(By.XPath(AS3DRows + "//picture"));

            // Assert that the number of items found is equal to 9
            Assert.AreEqual(itemsfound.Count, 9);

            // Click on the "Search 3D Models" link
            driver.FindElement(By.XPath(AS3DRows + aFindText + "Search 3D Models" + FindTextClose)).Click();
            Thread.Sleep(5000);

            // Get the baseline value
            var Baceline = driver.FindElement(By.XPath(AS2DTotalResults)).Text;

            // Click on the "Lights" label
            driver.FindElement(By.XPath(labelFindText + "Lights" + FindTextClose)).Click();
            Thread.Sleep(5000);

            // Assert that the baseline value is not equal to the current value
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(AS2DTotalResults)).Text);

            // Click on the "Lights" label again
            driver.FindElement(By.XPath(labelFindText + "Lights" + FindTextClose)).Click();
            Thread.Sleep(5000);

            // Assert that the baseline value is equal to the current value
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(AS2DTotalResults)).Text);

            // Click on the "Materials" label
            driver.FindElement(By.XPath(labelFindText + "Materials" + FindTextClose)).Click();
            Thread.Sleep(5000);

            // Assert that the baseline value is not equal to the current value
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(AS2DTotalResults)).Text);

            // Click on the "Materials" label again
            driver.FindElement(By.XPath(labelFindText + "Materials" + FindTextClose)).Click();
            Thread.Sleep(5000);

            // Assert that the baseline value is equal to the current value
            Assert.AreEqual(Baceline, driver.FindElement(By.XPath(AS2DTotalResults)).Text);

            // Click on the "Standard Content" label
            driver.FindElement(By.XPath(labelFindText + "Standard Content" + FindTextClose)).Click();
            Thread.Sleep(5000);

            // Assert that the baseline value is not equal to the current value
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(AS2DTotalResults)).Text);

            // Update the baseline value
            Baceline = driver.FindElement(By.XPath(AS2DTotalResults)).Text;

            // Click on the "Premium" label in the 3D subcategory panel
            driver.FindElement(By.XPath(Panal3DSubcategory + labelFindText + "Premium" + FindTextClose)).Click();
            Thread.Sleep(5000);

            // Assert that the baseline value is not equal to the current value
            Assert.AreNotEqual(Baceline, driver.FindElement(By.XPath(AS2DTotalResults)).Text);

        }



        [TearDown]
        public void TearDown()

        {
            driver.Quit();
            driver.Dispose();
        }

    }

}