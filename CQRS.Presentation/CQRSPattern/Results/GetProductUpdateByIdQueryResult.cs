﻿namespace CQRS.Presentation.CQRSPattern.Results
{
    public class GetProductUpdateByIdQueryResult
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
    }
}