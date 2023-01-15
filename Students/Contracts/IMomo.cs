﻿//
//  Copyright 2021  2021
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

using System;
using System.Threading.Tasks;

namespace Students.Contracts;

public interface IMomo
{
    public void Authenticate();

    public int DebitWallet(string walletType, string senderName, string senderNumber, decimal amount,
        string transactionId, string remarks);

    public string CreditWallet(string walletType, string receipientName, string receipientNumber,
        decimal amount, string transactionId, string remarks);

    public string GetTransactionStatus(string walletType, string transactionId);
    public string Find(Guid productId);
    public string vodaAirtel(string phone);

    public string SendPaymentToSRMS(string indexNo, decimal amount, string accountNumber, string feeType, string transactionId, DateTime transactionDate);

}


