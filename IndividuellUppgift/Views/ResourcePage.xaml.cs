using MongoDB.Driver;

namespace IndividuellUppgift.Views;

public partial class ResourcePage : ContentPage
{
    public Models.Resources Resource { get; set; }
    public ResourcePage()
    {
        InitializeComponent();
    }

    private async void OnHomeResourceClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private void OnResetResourceClicked(object sender, EventArgs e)
    {
        //Food
        oneKFood.Text = "0";
        tenKFood.Text = "0";
        fiftyKFood.Text = "0";
        onehundredfiftyKFood.Text = "0";
        fivehundredKFood.Text = "0";
        oneandahalfmillionFood.Text = "0";
        fiveMillionFood.Text = "0";

        //Wood
        oneKWood.Text = "0";
        tenKWood.Text = "0";
        fiftyKWood.Text = "0";
        onehundredfiftyKWood.Text = "0";
        fivehundredKWood.Text = "0";
        oneandahalfmillionWood.Text = "0";
        fiveMillionWood.Text = "0";
        //Stone
        oneKStone.Text = "0";
        tenKStone.Text = "0";
        fiftyKStone.Text = "0";
        onehundredfiftyKStone.Text = "0";
        fivehundredKStone.Text = "0";
        oneandahalfmillionStone.Text = "0";
        fiveMillionStone.Text = "0";
        //Gold
        oneKGold.Text = "0";
        tenKGold.Text = "0";
        fiftyKGold.Text = "0";
        onehundredfiftyKGold.Text = "0";
        fivehundredKGold.Text = "0";
        oneandahalfmillionGold.Text = "0";
        fiveMillionGold.Text = "0";
    }

    private async void OnGetClicked(object sender, EventArgs e)
    {
        var resourceData = await Data.DB.ResourceCollection().FindAsync(Builders<Models.Resources>.Filter.Empty);


        if (resourceData != null)
        {

            var resource = resourceData.FirstOrDefault();


            if (resource != null)
            {
                //Food
                oneKFood.Text = resource.Food1K.ToString();
                tenKFood.Text = resource.Food10K.ToString();
                fiftyKFood.Text = resource.Food50K.ToString();
                onehundredfiftyKFood.Text = resource.Food150K.ToString();
                fivehundredKFood.Text = resource.Food500K.ToString();
                oneandahalfmillionFood.Text = resource.Food150KK.ToString();
                fiveMillionFood.Text = resource.Food500KK.ToString();

                //Wood
                oneKWood.Text = resource.Wood1K.ToString();
                tenKWood.Text = resource.Wood10K.ToString();
                fiftyKWood.Text = resource.Wood50K.ToString();
                onehundredfiftyKWood.Text = resource.Wood150K.ToString();
                fivehundredKWood.Text = resource.Wood500K.ToString();
                oneandahalfmillionWood.Text = resource.Wood150KK.ToString();
                fiveMillionWood.Text = resource.Wood500KK.ToString();

                //Stone
                oneKStone.Text = resource.Stone750.ToString();
                tenKStone.Text = resource.Stone7500.ToString();
                fiftyKStone.Text = resource.Stone40K.ToString();
                onehundredfiftyKStone.Text = resource.Stone112K.ToString();
                fivehundredKStone.Text = resource.Stone375K.ToString();
                oneandahalfmillionStone.Text = resource.Stone112KK.ToString();
                fiveMillionStone.Text = resource.Stone112KK.ToString();

                //Gold
                oneKGold.Text = resource.Gold500.ToString();
                tenKGold.Text = resource.Gold3k.ToString();
                fiftyKGold.Text = resource.Gold15K.ToString();
                onehundredfiftyKGold.Text = resource.Gold50K.ToString();
                fivehundredKGold.Text = resource.Gold200K.ToString();
                oneandahalfmillionGold.Text = resource.Gold600K.ToString();
                fiveMillionGold.Text = resource.Gold300KK.ToString();

            }
            else
            {
                DataBaseButton.Text = "No Data Found";
            }
        }
        else
        {
            DataBaseButton.Text = "No data found, maybe a connection error to the database";
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        
            var resource = await Data.DB.ResourceCollection().AsQueryable().ToListAsync();
            if (resource.Count != 0)
            {

                
                Resource = resource.FirstOrDefault();
                //Food
                Resource.Food1K = int.Parse(oneKFood.Text == "" ? "0" : oneKFood.Text);
                Resource.Food10K = int.Parse(tenKFood.Text == "" ? "0" : tenKFood.Text);
                Resource.Food50K = int.Parse(fiftyKFood.Text == "" ? "0" : fiftyKFood.Text);
                Resource.Food150K = int.Parse(onehundredfiftyKFood.Text == "" ? "0" : onehundredfiftyKFood.Text);
                Resource.Food500K = int.Parse(fivehundredKFood.Text == "" ? "0" : fivehundredKFood.Text);
                Resource.Food150KK = int.Parse(oneandahalfmillionFood.Text == "" ? "0" : oneandahalfmillionFood.Text);
                Resource.Food500KK = int.Parse(fiveMillionFood.Text == "" ? "0" : fiveMillionFood.Text);

                //Wood
                Resource.Wood1K = int.Parse(oneKWood.Text == "" ? "0" : oneKFood.Text);
                Resource.Wood10K = int.Parse(tenKWood.Text == "" ? "0" : tenKFood.Text);
                Resource.Wood50K = int.Parse(fiftyKWood.Text == "" ? "0" : fiftyKFood.Text);
                Resource.Wood150K = int.Parse(onehundredfiftyKWood.Text == "" ? "0" : onehundredfiftyKFood.Text);
                Resource.Wood500K = int.Parse(fivehundredKWood.Text == "" ? "0" : fivehundredKFood.Text);
                Resource.Wood150KK = int.Parse(oneandahalfmillionWood.Text == "" ? "0" : oneandahalfmillionFood.Text);
                Resource.Wood500KK = int.Parse(fiveMillionWood.Text == "" ? "0" : fiveMillionFood.Text);
                //Stone
                Resource.Stone750 = int.Parse(oneKStone.Text == "" ? "0" : oneKStone.Text);
                Resource.Stone7500 = int.Parse(tenKStone.Text == "" ? "0" : tenKStone.Text);
                Resource.Stone40K = int.Parse(fiftyKStone.Text == "" ? "0" : fiftyKStone.Text);
                Resource.Stone375K = int.Parse(onehundredfiftyKStone.Text == "" ? "0" : onehundredfiftyKStone.Text);
                Resource.Stone112K = int.Parse(fivehundredKStone.Text == "" ? "0" : fivehundredKStone.Text);
                Resource.Stone112KK = int.Parse(oneandahalfmillionStone.Text == "" ? "0" : oneandahalfmillionStone.Text);
                Resource.Stone375KK = int.Parse(fiveMillionStone.Text == "" ? "0" : fiveMillionStone.Text);
                //Gold
                Resource.Gold500 = int.Parse(oneKGold.Text == "" ? "0" : oneKGold.Text);
                Resource.Gold3k = int.Parse(tenKGold.Text == "" ? "0" : tenKGold.Text);
                Resource.Gold15K = int.Parse(fiftyKGold.Text == "" ? "0" : fiftyKGold.Text);
                Resource.Gold50K = int.Parse(onehundredfiftyKGold.Text == "" ? "0" : onehundredfiftyKGold.Text);
                Resource.Gold200K = int.Parse(fivehundredKGold.Text == "" ? "0" : fivehundredKGold.Text);
                Resource.Gold600K = int.Parse(oneandahalfmillionGold.Text == "" ? "0" : oneandahalfmillionGold.Text);
                Resource.Gold300KK = int.Parse(fiveMillionGold.Text == "" ? "0" : fiveMillionGold.Text);
                var filter = Builders<Models.Resources>.Filter.Empty;
                await Data.DB.ResourceCollection().ReplaceOneAsync(filter, Resource);
            }
            else
            {
                Models.Resources newResources = new Models.Resources()
                {
                    Id = Guid.NewGuid(),
                    //Food
                    Food1K = int.Parse(oneKFood.Text),
                    Food10K = int.Parse(tenKFood.Text),
                    Food50K = int.Parse(fiftyKFood.Text),
                    Food150K = int.Parse(onehundredfiftyKFood.Text),
                    Food500K = int.Parse(fivehundredKFood.Text),
                    Food150KK = int.Parse(oneandahalfmillionFood.Text),
                    Food500KK = int.Parse(fiveMillionFood.Text),
                    //Wood
                    Wood1K = int.Parse(oneKWood.Text),
                    Wood10K = int.Parse(tenKWood.Text),
                    Wood50K = int.Parse(fiftyKWood.Text),
                    Wood150K = int.Parse(onehundredfiftyKWood.Text),
                    Wood500K = int.Parse(fivehundredKWood.Text),
                    Wood150KK = int.Parse(oneandahalfmillionWood.Text),
                    Wood500KK = int.Parse(fiveMillionWood.Text),

                    //Stone
                    Stone750 = int.Parse(oneKStone.Text),
                    Stone7500 = int.Parse(tenKStone.Text),
                    Stone40K = int.Parse(fiftyKStone.Text),
                    Stone375K = int.Parse(onehundredfiftyKStone.Text),
                    Stone112K = int.Parse(fivehundredKStone.Text),
                    Stone112KK = int.Parse(oneandahalfmillionStone.Text),
                    Stone375KK = int.Parse(fiveMillionStone.Text),

                    //Gold
                    Gold500 = int.Parse(oneKGold.Text),
                    Gold3k = int.Parse(tenKGold.Text),
                    Gold15K = int.Parse(fiftyKGold.Text),
                    Gold50K = int.Parse(onehundredfiftyKGold.Text),
                    Gold200K = int.Parse(fivehundredKGold.Text),
                    Gold600K = int.Parse(oneandahalfmillionGold.Text),
                    Gold300KK = int.Parse(fiveMillionGold.Text),
                };
                await Data.DB.ResourceCollection().InsertOneAsync(newResources);
            }
            if (int.TryParse(oneKFood.Text, out int foodNum1) && int.TryParse(tenKFood.Text, out int foodNum2) && int.TryParse(fiftyKFood.Text, out int foodNum3)
                && int.TryParse(onehundredfiftyKFood.Text, out int foodNum4) && int.TryParse(fivehundredKFood.Text, out int foodNum5)
                && int.TryParse(oneandahalfmillionFood.Text, out int foodNum6) && int.TryParse(fiveMillionFood.Text, out int foodNum7)
                && int.TryParse(oneKWood.Text, out int woodNum1) && int.TryParse(tenKWood.Text, out int woodNum2)
                && int.TryParse(fiftyKWood.Text, out int woodNum3) && int.TryParse(onehundredfiftyKWood.Text, out int woodNum4) && int.TryParse(fivehundredKWood.Text, out int woodNum5)
                && int.TryParse(oneandahalfmillionWood.Text, out int woodNum6) && int.TryParse(fiveMillionWood.Text, out int woodNum7) && int.TryParse(oneKStone.Text, out int stoneNum1)
                && int.TryParse(tenKStone.Text, out int stoneNum2) && int.TryParse(fiftyKStone.Text, out int stoneNum3) && int.TryParse(onehundredfiftyKStone.Text, out int stoneNum4)
                && int.TryParse(fivehundredKStone.Text, out int stoneNum5) && int.TryParse(oneandahalfmillionStone.Text, out int stoneNum6) && int.TryParse(fiveMillionStone.Text, out int stoneNum7)
                && int.TryParse(oneKGold.Text, out int goldNum1) && int.TryParse(tenKGold.Text, out int goldNum2) && int.TryParse(fiftyKGold.Text, out int goldNum3)
                && int.TryParse(onehundredfiftyKGold.Text, out int goldNum4) && int.TryParse(fivehundredKGold.Text, out int goldNum5) && int.TryParse(oneandahalfmillionGold.Text, out int goldNum6)
                && int.TryParse(fiveMillionGold.Text, out int goldNum7))
            {
                //Food
                int foodSum = (foodNum1 * 1000) + (foodNum2 * 10000) + (foodNum3 * 50000) + (foodNum4 * 150000) +
                    (foodNum5 * 500000) + (foodNum6 * 1500000) + (foodNum7 * 5000000);
                //Wood
                int woodSum = (woodNum1 * 1000) + (woodNum2 * 10000) + (woodNum3 * 50000) + (woodNum4 * 150000) +
                    (woodNum5 * 500000) + (woodNum6 * 1500000) + (woodNum7 * 5000000);
                //Stone
                int stoneSum = (stoneNum1 * 750) + (stoneNum2 * 7500) + (stoneNum3 * 37500) + (stoneNum4 * 112500) +
                    (stoneNum5 * 375000) + (stoneNum6 * 1125000) + (stoneNum7 * 3750000);
                //Gold
                int goldSum = (goldNum1 * 500) + (goldNum2 * 3000) + (goldNum3 * 15000) + (goldNum4 * 50000) +
                    (goldNum5 * 200000) + (goldNum6 * 600000) + (goldNum7 * 3000000);

                if (foodSum > 1000000)
                {
                    TotalFood.Text = $"Total food: {foodSum / 1000000}M";
                }
                
                else if (foodSum < 1000000)
                {
                    TotalFood.Text = $"Total food: {foodSum / 1000}K";
                }
                if (woodSum > 1000000)
                {
                    TotalWood.Text = $"Total wood: {woodSum / 1000000}M";
                }

                else if (woodSum < 1000000)
                {
                    TotalWood.Text = $"Total wood: {woodSum / 1000}K";
                }
                if (stoneSum > 1000000)
                {
                    TotalStone.Text = $"Total stone: {stoneSum / 1000000}M";
                }

                else if (stoneSum < 1000000)
                {
                    TotalStone.Text = $"Total stone: {stoneSum / 1000}K";
                }
                if (goldSum > 1000000)
                {
                    TotalGold.Text = $"Total Gold: {goldSum / 1000000}M";
                }

                else if (goldSum < 1000000)
                {
                    TotalGold.Text = $"Total Gold: {goldSum / 1000}K";
                }

            }

            else
            {

                TotalFood.Text = "Please enter valid numbers in all fields.";

                TotalWood.Text = "Please enter valid numbers in all fields";

                TotalStone.Text = "Please enter valid numbers in all fields";

                TotalGold.Text = "Please enter valid numbers in all fields";


            }
    }
       
    
}
        
        
    
        
    

    