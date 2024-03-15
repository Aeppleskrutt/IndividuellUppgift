using IndividuellUppgift.Models;
using IndividuellUppgift.ViewModels;
using MongoDB.Driver;
using System.Data.Common;
using System.Net.Http.Headers;

namespace IndividuellUppgift.Views;

public partial class UniversalPage : ContentPage
{
    public Models.Speedups Speedup { get; set; }

    

    public UniversalPage()
	{
        
        InitializeComponent();

    }
    
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        

        var speedup = await Data.DB.UniversalCollection().AsQueryable().ToListAsync();
        if (speedup.Count != 0)
        {

            // == "" ? "0" : oneMinute.Text
            Speedup = speedup.FirstOrDefault();
            //Universal
            Speedup.UniversalOneMin = int.Parse(oneMinute.Text == "" ? "0" : oneMinute.Text);
            Speedup.UniversalFiveMin = int.Parse(fiveMinute.Text == "" ? "0" : fiveMinute.Text);
            Speedup.UniversalTenMin = int.Parse(tenMinute.Text == "" ? "0" : tenMinute.Text);
            Speedup.UniversalFifteenMin = int.Parse(fifteenMinute.Text == "" ? "0" : fifteenMinute.Text);
            Speedup.UniversalThirtyMin = int.Parse(thirtyMinute.Text == "" ? "0" : thirtyMinute.Text);
            Speedup.UniversalSixtyMin = int.Parse(sixtyMinute.Text == "" ? "0" : sixtyMinute.Text);
            Speedup.UniversalThreeHour = int.Parse(threeHour.Text == "" ? "0" : threeHour.Text);
            Speedup.UniversalEightHour = int.Parse(eightHour.Text == "" ? "0" : eightHour.Text);
            Speedup.UniversalTwentyFourHour = int.Parse(twentyfourHour.Text == "" ? "0" : twentyfourHour.Text);
            //Training
            Speedup.TrainingOneMin = int.Parse(oneMinute2.Text == "" ? "0" : oneMinute2.Text);
            Speedup.TrainingFiveMin = int.Parse(fiveMinute2.Text == "" ? "0" : fiveMinute2.Text);
            Speedup.TrainingTenMin = int.Parse(tenMinute2.Text == "" ? "0" : tenMinute2.Text);
            Speedup.TrainingFifteenMin = int.Parse(fifteenMinute2.Text == "" ? "0" : fifteenMinute2.Text);
            Speedup.TrainingThirtyMin = int.Parse(thirtyMinute2.Text == "" ? "0" : thirtyMinute2.Text);
            Speedup.TrainingSixtyMin = int.Parse(sixtyMinute2.Text == "" ? "0" : sixtyMinute2.Text);
            Speedup.TrainingThreeHour = int.Parse(threeHour2.Text == "" ? "0" : threeHour2.Text);
            Speedup.TrainingEightHour = int.Parse(eightHour2.Text == "" ? "0" : eightHour2.Text);
            Speedup.TrainingTwentyFourHour = int.Parse(twentyfourHour2.Text == "" ? "0" : twentyfourHour2.Text);
            //Research
            Speedup.ResearchOneMin = int.Parse(oneMinute3.Text == "" ? "0" : oneMinute3.Text);
            Speedup.ResearchFiveMin = int.Parse(fiveMinute3.Text == "" ? "0" : fiveMinute3.Text);
            Speedup.ResearchTenMin = int.Parse(tenMinute3.Text == "" ? "0" : tenMinute3.Text);
            Speedup.ResearchFifteenMin = int.Parse(fifteenMinute3.Text == "" ? "0" : fifteenMinute3.Text);
            Speedup.ResearchThirtyMin = int.Parse(thirtyMinute3.Text == "" ? "0" : thirtyMinute3.Text);
            Speedup.ResearchSixtyMin = int.Parse(sixtyMinute3.Text == "" ? "0" : sixtyMinute3.Text);
            Speedup.ResearchThreeHour = int.Parse(threeHour3.Text == "" ? "0" : threeHour3.Text);
            Speedup.ResearchEightHour = int.Parse(eightHour3.Text == "" ? "0" : eightHour3.Text);
            Speedup.ResearchTwentyFourHour = int.Parse(twentyfourHour3.Text == "" ? "0" : twentyfourHour3.Text);
            //Healing
            Speedup.HealingOneMin = int.Parse(oneMinute4.Text == "" ? "0" : oneMinute4.Text);
            Speedup.HealingFiveMin = int.Parse(fiveMinute4.Text == "" ? "0" : fiveMinute4.Text);
            Speedup.HealingTenMin = int.Parse(tenMinute4.Text == "" ? "0" : tenMinute4.Text);
            Speedup.HealingFifteenMin = int.Parse(fifteenMinute4.Text == "" ? "0" : fifteenMinute4.Text);
            Speedup.HealingThirtyMin = int.Parse(thirtyMinute4.Text == "" ? "0" : thirtyMinute4.Text);
            Speedup.HealingSixtyMin = int.Parse(sixtyMinute4.Text == "" ? "0" : sixtyMinute4.Text);
            Speedup.HealingThreeHour = int.Parse(threeHour4.Text == "" ? "0" : threeHour4.Text);
            Speedup.HealingEightHour = int.Parse(eightHour4.Text == "" ? "0" : eightHour4.Text);
            Speedup.HealingTwentyFourHour = int.Parse(twentyfourHour4.Text == "" ? "0" : twentyfourHour4.Text);
            var filter = Builders<Models.Speedups>.Filter.Empty;
            await Data.DB.UniversalCollection().ReplaceOneAsync(filter, Speedup);
        }
        else
        {
            Models.Speedups newSpeedup = new Models.Speedups()
            {
                Id = Guid.NewGuid(),
                //Universal
                UniversalOneMin = int.Parse(oneMinute.Text),
                UniversalFiveMin = int.Parse(fiveMinute.Text),
                UniversalTenMin = int.Parse(tenMinute.Text),
                UniversalFifteenMin = int.Parse(fifteenMinute.Text),
                UniversalThirtyMin = int.Parse(thirtyMinute.Text),
                UniversalSixtyMin = int.Parse(sixtyMinute.Text),
                UniversalThreeHour = int.Parse(threeHour.Text),
                UniversalEightHour = int.Parse(eightHour.Text),
                UniversalTwentyFourHour = int.Parse(twentyfourHour.Text),
                //Training
                TrainingOneMin = int.Parse(oneMinute2.Text),
                TrainingFiveMin = int.Parse(fiveMinute2.Text),
                TrainingTenMin = int.Parse(tenMinute2.Text),
                TrainingFifteenMin = int.Parse(fifteenMinute2.Text),
                TrainingThirtyMin = int.Parse(thirtyMinute2.Text),
                TrainingSixtyMin = int.Parse(sixtyMinute2.Text),
                TrainingThreeHour = int.Parse(threeHour2.Text),
                TrainingEightHour = int.Parse(eightHour2.Text),
                TrainingTwentyFourHour = int.Parse(twentyfourHour2.Text),
                //Research
                ResearchOneMin = int.Parse(oneMinute3.Text),
                ResearchFiveMin = int.Parse(fiveMinute3.Text),
                ResearchTenMin = int.Parse(tenMinute3.Text),
                ResearchFifteenMin = int.Parse(fifteenMinute3.Text),
                ResearchThirtyMin = int.Parse(thirtyMinute3.Text),
                ResearchSixtyMin = int.Parse(sixtyMinute3.Text),
                ResearchThreeHour = int.Parse(threeHour3.Text),
                ResearchEightHour = int.Parse(eightHour3.Text),
                ResearchTwentyFourHour = int.Parse(twentyfourHour3.Text),
                //Healing
                HealingOneMin = int.Parse(oneMinute4.Text),
                HealingFiveMin = int.Parse(fiveMinute4.Text),
                HealingTenMin = int.Parse(tenMinute4.Text),
                HealingFifteenMin = int.Parse(fifteenMinute4.Text),
                HealingThirtyMin = int.Parse(thirtyMinute4.Text),
                HealingSixtyMin = int.Parse(sixtyMinute4.Text),
                HealingThreeHour = int.Parse(threeHour4.Text),
                HealingEightHour = int.Parse(eightHour4.Text),
                HealingTwentyFourHour = int.Parse(twentyfourHour4.Text),

            };
            await Data.DB.UniversalCollection().InsertOneAsync(newSpeedup);
        }

        //Kollar om alla entries är Int
        if (int.TryParse(oneMinute.Text, out int uniNum1) && int.TryParse(fiveMinute.Text, out int fiveMNum1) && int.TryParse(tenMinute.Text, out int tenMNum1) 
            && int.TryParse(fifteenMinute.Text, out int fifteenMNum1) && int.TryParse(thirtyMinute.Text, out int thirtyMNum1) && int.TryParse(sixtyMinute.Text, out int sixtyMNum1) 
            && int.TryParse(threeHour.Text, out int threeHNum1) && int.TryParse(eightHour.Text, out int eightHNum1) && int.TryParse(twentyfourHour.Text, out int twentyFourHNum1) 
            && int.TryParse(oneMinute3.Text, out int uniNum3) && int.TryParse(fiveMinute3.Text, out int fiveMNum3) && int.TryParse(tenMinute3.Text, out int tenMNum3)
            && int.TryParse(fifteenMinute3.Text, out int fifteenMNum3) && int.TryParse(thirtyMinute3.Text, out int thirtyMNum3) && int.TryParse(sixtyMinute3.Text, out int sixtyMNum3)
            && int.TryParse(threeHour3.Text, out int threeHNum3) && int.TryParse(eightHour3.Text, out int eightHNum3) && int.TryParse(twentyfourHour3.Text, out int twentyFourHNum3) 
            && int.TryParse(oneMinute2.Text, out int uniNum2) && int.TryParse(fiveMinute2.Text, out int fiveMNum2) && int.TryParse(tenMinute2.Text, out int tenMNum2)
            && int.TryParse(fifteenMinute2.Text, out int fifteenMNum2) && int.TryParse(thirtyMinute2.Text, out int thirtyMNum2) && int.TryParse(sixtyMinute2.Text, out int sixtyMNum2)
            && int.TryParse(threeHour2.Text, out int threeHNum2) && int.TryParse(eightHour2.Text, out int eightHNum2) && int.TryParse(twentyfourHour2.Text, out int twentyFourHNum2) 
            && int.TryParse(oneMinute4.Text, out int uniNum4) && int.TryParse(fiveMinute4.Text, out int fiveMNum4) && int.TryParse(tenMinute4.Text, out int tenMNum4)
            && int.TryParse(fifteenMinute4.Text, out int fifteenMNum4) && int.TryParse(thirtyMinute4.Text, out int thirtyMNum4) && int.TryParse(sixtyMinute4.Text, out int sixtyMNum4)
            && int.TryParse(threeHour4.Text, out int threeHNum4) && int.TryParse(eightHour4.Text, out int eightHNum4) && int.TryParse(twentyfourHour4.Text, out int twentyFourHNum4))
        {
            //Universal
            int uniSum = uniNum1 + (fiveMNum1 * 5) + (tenMNum1 * 10) + (fifteenMNum1 * 15) +
                (thirtyMNum1 * 30) + (sixtyMNum1 * 60) + (threeHNum1 * 180) + (eightHNum1 * 480) + (twentyFourHNum1 * 1440);
            //Research
            int researchSum = uniNum3 + (fiveMNum3 * 5) + (tenMNum3 * 10) + (fifteenMNum3 * 15) +
                (thirtyMNum3 * 30) + (sixtyMNum3 * 60) + (threeHNum3 * 180) + (eightHNum3 * 480) + (twentyFourHNum3 * 1440);
            //Training
            int trainingSum = uniNum2 + (fiveMNum2 * 5) + (tenMNum2 * 10) + (fifteenMNum2 * 15) +
                (thirtyMNum2 * 30) + (sixtyMNum2 * 60) + (threeHNum2 * 180) + (eightHNum2 * 480) + (twentyFourHNum2 * 1440);
            //Healing
            int healingSum = uniNum4 + (fiveMNum4 * 5) + (tenMNum4 * 10) + (fifteenMNum4 * 15) +
                (thirtyMNum4 * 30) + (sixtyMNum4 * 60) + (threeHNum4 * 180) + (eightHNum4 * 480) + (twentyFourHNum4 * 1440);

            int urDaySum = ((uniSum + researchSum) / 1440);
            int urHourSum = ((uniSum + researchSum) % 1440) / 60;
            int urMinuteSum = ((uniSum + researchSum) % 60);

            int utDaySum = ((uniSum + trainingSum)) / 1440;
            int utHourSum = ((uniSum + trainingSum) % 1440) / 60;
            int utMinuteSum = ((uniSum + trainingSum) % 60);

            int uhDaySum = ((uniSum + healingSum)) / 1440;
            int uhHourSum = ((uniSum + healingSum) % 1440) / 60;
            int uhMinuteSum = ((uniSum + healingSum) % 60);

            int uDaySum = (uniSum / 1440);
            int uHourSum = (uniSum % 1440) / 60;
            int uMinuteSum = (uniSum % 60);

            int hDaySum = (healingSum / 1440);
            int hHourSum = (healingSum % 1440) / 60;
            int hMinuteSum = (healingSum % 60);

            int tDaySum = (trainingSum / 1440);
            int tHourSum = (trainingSum % 1440) / 60;
            int tMinuteSum = (trainingSum % 60);

            int rDaySum = (researchSum / 1440);
            int rHourSum = (researchSum % 1440) / 60;
            int rMinuteSum = (researchSum % 60);

            UniAndRes.Text = $"Universal+Research: {urDaySum}d {urHourSum}h {urMinuteSum}m = {uniSum + researchSum} minutes";

            UniAndTrain.Text = $"Universal+Training: {utDaySum}d {utHourSum}h {utMinuteSum}m = {uniSum + trainingSum} minutes";

            UniAndHeal.Text = $"Universal+Healing: {uhDaySum}d {uhHourSum}h {uhMinuteSum}m = {uniSum + healingSum} minutes";

            Universal.Text = $"Universal: {uDaySum}d {uHourSum}h {uMinuteSum}m = {uniSum} minutes";

            Healing.Text = $"Healing: {hDaySum}d {hHourSum}h {hMinuteSum}m = {healingSum} minutes";

            Training.Text = $"Training: {tDaySum}d {tHourSum}h {tMinuteSum}m = {trainingSum} minutes";

            Research.Text = $"Research: {rDaySum}d {rHourSum}h {rMinuteSum}m = {researchSum} minutes";


        }
        
        else
        {

            UniAndRes.Text = "Please enter valid numbers in all fields.";

            UniAndTrain.Text = "Please enter valid numbers in all fields";

            UniAndHeal.Text = "Please enter valid numbers in all fields";

            Universal.Text = "Please enter valid numbers in all fields";

            Healing.Text = "Please enter valid numbers in all fields";

            Training.Text = "Please enter valid numbers in all fields";

            Research.Text = "Please enter valid numbers in all fields";
        }
    }

    private async void OnGetClicked(object sender, EventArgs e)
    {
        var speedupData = await Data.DB.UniversalCollection().FindAsync(Builders<Models.Speedups>.Filter.Empty);

        
        if (speedupData != null)
        {
            
            var speedup = speedupData.FirstOrDefault();

            
            if (speedup != null)
            {
                // Universal
                oneMinute.Text = speedup.UniversalOneMin.ToString();
                fiveMinute.Text = speedup.UniversalFiveMin.ToString();
                tenMinute.Text = speedup.UniversalTenMin.ToString();
                fifteenMinute.Text = speedup.UniversalFifteenMin.ToString();
                thirtyMinute.Text = speedup.UniversalThirtyMin.ToString();
                sixtyMinute.Text = speedup.UniversalSixtyMin.ToString();
                threeHour.Text = speedup.UniversalThreeHour.ToString();
                eightHour.Text = speedup.UniversalEightHour.ToString();
                twentyfourHour.Text = speedup.UniversalTwentyFourHour.ToString();
                // Training
                oneMinute2.Text = speedup.TrainingOneMin.ToString();
                fiveMinute2.Text = speedup.TrainingFiveMin.ToString();
                tenMinute2.Text = speedup.TrainingTenMin.ToString();
                fifteenMinute2.Text = speedup.TrainingFifteenMin.ToString();
                thirtyMinute2.Text = speedup.TrainingThirtyMin.ToString();
                sixtyMinute2.Text = speedup.TrainingSixtyMin.ToString();
                threeHour2.Text = speedup.TrainingThreeHour.ToString();
                eightHour2.Text = speedup.TrainingEightHour.ToString();
                twentyfourHour2.Text = speedup.TrainingTwentyFourHour.ToString();
                //Research
                oneMinute3.Text = speedup.TrainingOneMin.ToString();
                fiveMinute3.Text = speedup.TrainingFiveMin.ToString();
                tenMinute3.Text = speedup.TrainingTenMin.ToString();
                fifteenMinute3.Text = speedup.TrainingFifteenMin.ToString();
                thirtyMinute3.Text = speedup.TrainingThirtyMin.ToString();
                sixtyMinute3.Text = speedup.TrainingSixtyMin.ToString();
                threeHour3.Text = speedup.TrainingThreeHour.ToString();
                eightHour3.Text = speedup.TrainingEightHour.ToString();
                twentyfourHour3.Text = speedup.TrainingTwentyFourHour.ToString();
                //Healing
                oneMinute4.Text = speedup.TrainingOneMin.ToString();
                fiveMinute4.Text = speedup.TrainingFiveMin.ToString();
                tenMinute4.Text = speedup.TrainingTenMin.ToString();
                fifteenMinute4.Text = speedup.TrainingFifteenMin.ToString();
                thirtyMinute4.Text = speedup.TrainingThirtyMin.ToString();
                sixtyMinute4.Text = speedup.TrainingSixtyMin.ToString();
                threeHour4.Text = speedup.TrainingThreeHour.ToString();
                eightHour4.Text = speedup.TrainingEightHour.ToString();
                twentyfourHour4.Text = speedup.TrainingTwentyFourHour.ToString();
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

    private void OnResetClicked(object sender, EventArgs e)
    {
        oneMinute.Text = "0";
        fiveMinute.Text = "0";
        tenMinute.Text = "0";
        fifteenMinute.Text = "0";
        thirtyMinute.Text = "0";
        sixtyMinute.Text = "0";
        threeHour.Text = "0";
        eightHour.Text = "0";
        twentyfourHour.Text = "0";
        //Training
        oneMinute2.Text = "0";
        fiveMinute2.Text = "0";
        tenMinute2.Text = "0";
        fifteenMinute2.Text = "0";
        thirtyMinute2.Text = "0";
        sixtyMinute2.Text = "0";
        threeHour2.Text = "0";
        eightHour2.Text = "0";
        twentyfourHour2.Text = "0";
        //Research
        oneMinute3.Text = "0";
        fiveMinute3.Text = "0";
        tenMinute3.Text = "0";
        fifteenMinute3.Text = "0";
        thirtyMinute3.Text = "0";
        sixtyMinute3.Text = "0";
        threeHour3.Text = "0";
        eightHour3.Text = "0";
        twentyfourHour3.Text = "0";
        //Healing
        oneMinute4.Text = "0";
        fiveMinute4.Text = "0";
        tenMinute4.Text = "0";
        fifteenMinute4.Text = "0";
        thirtyMinute4.Text = "0";
        sixtyMinute4.Text = "0";
        threeHour4.Text = "0";
        eightHour4.Text = "0";
        twentyfourHour4.Text = "0";
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        

        await Navigation.PushAsync(new MainPage());
    }
}