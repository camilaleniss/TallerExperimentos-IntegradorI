using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsDesign.Model
{
    public class Experiment
    {
        private List<Test<T>> tests { get; set; }

        public Experiment()
        {

        }

        public void ExecuteExperiment()
        {

        }

        public void InitTests()
        {
            InitMatrixTests();
            CreateTests();
        }

        public void InitMatrixTests()
        {

        }

        public void CreateTests()
        {

        }

        public void ExecuteTest(Test<T> test)
        {

            test.ExecuteTest();
        }

        public void WriteCVS()
        {

        }




        
    }
}
