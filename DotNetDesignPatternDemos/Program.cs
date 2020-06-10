using System;
using DotNetDesignPatternDemos.Creational.Builder;
using DotNetDesignPatternDemos.Creational.Factory;
using DotNetDesignPatternDemos.Creational.Prototype;
using DotNetDesignPatternDemos.Creational.Singleton;
using DotNetDesignPatternDemos.SOLID;
using DotNetDesignPatternDemos.Structural;

namespace DotNetDesignPatternDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            // SOLID
            //SingleRepositoryPrinciple.Start();
            //OpenClosePrinciple.Start();
            //LiskovSubtitutionPrinciple.Start();
            //InterfaceSegregationPrinciple.Start();
            //DependencyInversionPrinciple.Start();


            /* Creational */

            // Builder
            //Builder.Start();
            //FluentBuilderInhWithRecGenerics.Start();
            // FunctionalBuilder.Start();
            //FacetedBuilder.Start();
            //BuilderCodeExcercise.Start();
            //BuilderCodeExcerciseByDmitri.Start();

            // Factory
            //PointExample.Start();
            //AsynchronousFactotyMethod.Start();
            //AbstractFactory.Start();
            //FactoryCodeExcecise.Start();

            // Prototype
            //ICloneableIsBad.Start();
            //CopyConstructor.Start();
            //DeepCopyInterface.Start();
            //CopyThroughSerialization.Start();
            //PrototypeCodeExcercise.Start();
            //PrototypeCodeExcerciseByDmitri.Start();

            // Singleton
            //SingletonImplementation.Start();
            //SingletonInDependencyInjection.Start();
            //Monostate.Start();
            //PerThreadSingleton38.Start();
            //AmbientContext.Start();
            //SingletonCodeExcercise.Start();



            /* Structural */
            //VectorRasterDemo.Start();
            //AdapterCaching.Start();
            //GenericValueAdapter.Start();
            AdapterInDependencyInjection.Start();
        }
    }
}
