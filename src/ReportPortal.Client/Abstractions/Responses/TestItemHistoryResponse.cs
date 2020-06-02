﻿using ReportPortal.Client.Abstractions.Models;
using ReportPortal.Client.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ReportPortal.Client.Abstractions.Responses
{
    [DataContract]
    public class TestItemHistoryContainer
    {
        [DataMember(Name = "testCaseHash")]
        public string TestCaseHash { get; set; }

        [DataMember(Name = "resources")]
        public IEnumerable<TestItemHistoryResponse> Resources { get; set; }
    }

    [DataContract]
    public class TestItemHistoryResponse
    {
        [DataMember(Name = "launchNumber")]
        public long LaunchNumber { get; set; }

        [DataMember(Name = "launchId")]
        public string LaunchId { get; set; }

        [DataMember(Name = "startTime")]
        public string StartTimeString { get; set; }

        public DateTime StartTime
        {
            get
            {
                return DateTimeConverter.ConvertTo(StartTimeString);
            }
            set
            {
                StartTimeString = DateTimeConverter.ConvertFrom(value);
            }
        }

        [DataMember(Name = "launchStatus")]
        public string LaunchStatusString { get; set; }

        public Status LaunchStatus { get { return EnumConverter.ConvertTo<Status>(LaunchStatusString); } set { LaunchStatusString = EnumConverter.ConvertFrom(value); } }

        [DataMember(Name = "resources")]
        public IEnumerable<TestItemResponse> Resources { get; set; }
    }
}
