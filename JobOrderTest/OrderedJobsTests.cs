using System;
using NUnit.Framework;
using OrderedJobs;

namespace JobOrderTest
{
    [TestFixture]
    public class OrderedJobsTests
    {
        [Test]
        public void EmptyStringShouldReturnEmptySequence()
        {
            var sequence = "";
            Assert.That(JobOrder.OrderJobs(""), Is.EqualTo(sequence));
        }
        
        [Test]
        public void StringAShouldReturnSingleJobA()
        {
            var sequence = "a";
            var jobList = "a => ";
            Assert.That(JobOrder.OrderJobs(jobList), Is.EqualTo(sequence));
        }
        
        [Test]
        public void StringAShouldReturnSingleJobB()
        {
            var sequence = "b";
            var jobList = "b => ";
            Assert.That(JobOrder.OrderJobs(jobList), Is.EqualTo(sequence));
        }
        
        [Test]
        public void MultipleJobsShouldReturnThoseJobs()
        {
            var sequence = "abc";
            var jobList = "a => \nb => \nc => ";
            Assert.That(JobOrder.OrderJobs(jobList), Is.EqualTo(sequence));
        }
        
        [Test]
        public void MultipleJobsSingleDependancy()
        {
            var sequence = "acb";
            var jobList = "a => \nb => c \nc => ";
            Assert.That(JobOrder.OrderJobs(jobList), Is.EqualTo(sequence));
        }
        
        [Test]
        public void MultipleJobsTwoDependancies()
        {
            var sequence = "afcb";
            var jobList = "a => \nb => c \nc => f \nf => ";
            Assert.That(JobOrder.OrderJobs(jobList), Is.EqualTo(sequence));
        }
        
        [Test]
        public void MultipleJobs()
        {
            var sequence = "adfcbe";
            var jobList = "a => \nb => c \nc => f \nd => a \ne => b \nf => ";
            Assert.That(JobOrder.OrderJobs(jobList), Is.EqualTo(sequence));
        } 
        
        [Test]
        public void multiplejobs()
        {
            var jobList = "a => b \nc => \nb => c ";
            Assert.That(JobOrder.OrderJobs(jobList), Is.EqualTo("cba"));
        }
        
        [Test]
        public void CircularDependencyJobs()
        {
            var jobList = "a => \nb => c \nc => f \nd => a \ne => \nf => b ";
            Assert.That(JobOrder.OrderJobs(jobList), Is.EqualTo("circular dependancy not allowed"));
        }

        
    }
}