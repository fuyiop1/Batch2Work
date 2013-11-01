using System;
using System.Collections.Generic;
using Batch2Work.Models;

namespace Batch2Work.Helpers
{
    public class SampleDataHelper
    {
        private static readonly Random Rnd = new Random();

        public static IList<ActionGridItem> GenerateActionGridItems(int numberOfItemsToCreate)
        {
            var dictionary = new SortedDictionary<string, ActionGridItem>();
            int index = 1;
            for (int i = 1; i <= numberOfItemsToCreate; i++)
            {
                var actionGridItem = CreateActionGridItem();
                dictionary.Add(actionGridItem.Key + index, actionGridItem);
                index++;
            }
            return new List<ActionGridItem>(dictionary.Values);
        }

        public static TreeModel GenerateTreeModel()
        {
            
            var rootNode = new TreeNode(1, "Test Building", GetImageUrl());
            int index = 2;

            for (int loopFloor = 1; loopFloor <= 10; loopFloor++)
            {
                var floorNode = new TreeNode(index, "Floor " + loopFloor, GetImageUrl());
                rootNode.AddChildNode(floorNode);
                index++;
                for (int loopArea = 1; loopArea <= 10; loopArea++)
                {
                    var areaNode = new TreeNode(index, "Area " + loopArea, GetImageUrl());
                    floorNode.AddChildNode(areaNode);
                    index++;
                    for (int loopItem = 1; loopItem <= 10; loopItem++)
                    {
                        var itemNode = new TreeNode(index, "Item " + loopArea + " - Extra Information " + loopItem, GetImageUrl());
                        areaNode.AddChildNode(itemNode);
                        index++;
                    }
                }
            }

            return new TreeModel(rootNode);
        }

        private static ActionGridItem CreateActionGridItem()
        {
            var actionGridItem = new ActionGridItem
            {
                Building = "Building " + Rnd.Next(1, 5),
                Floor = "Floor " + Rnd.Next(1, 10),
                Area = "Area " + Rnd.Next(1, 10),
                Item = "Item " + Rnd.Next(1, 10),
                ProductType = "ProductType " + Rnd.Next(1, 5),
                AsbestosType = "AsbestosType " + Rnd.Next(1, 5),
                Quantity = "Quantity " + Rnd.Next(1, 5),
                MaScore = Rnd.Next(0, 3),
                PaScore = Rnd.Next(0, 9)
            };
            actionGridItem.RiskScore = actionGridItem.MaScore + actionGridItem.PaScore;
            actionGridItem.RiskCategory = "RiskCategory " + actionGridItem.RiskScore;
            actionGridItem.RecAction = "RecAction " + Rnd.Next(1, 5);
            return actionGridItem;
        }

        private static string GetImageUrl()
        {
            var rnd = Rnd.Next(1, 4);
            if (rnd == 1)
                return "~/Content/images/flag_red.png";
            if (rnd == 2)
                return "~/Content/images/flag_yellow.png";
            if (rnd == 3)
                return "~/Content/images/flag_green.png";
            
            return "~/Content/images/flag_blue.png";

        }
    }
}