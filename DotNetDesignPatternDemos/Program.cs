using System;
using DotNetDesignPatternDemos.Creational.Builder;
using DotNetDesignPatternDemos.Creational.Factory;
using DotNetDesignPatternDemos.Creational.Prototype;
using DotNetDesignPatternDemos.Creational.Singleton;
using DotNetDesignPatternDemos.SOLID;
using DotNetDesignPatternDemos.Structural;
using DotNetDesignPatternDemos.Structural.Adapter;
using DotNetDesignPatternDemos.Structural.Bridge;
using DotNetDesignPatternDemos.Structural.Composite;

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

            // Adapter
            //VectorRasterDemo.Start();
            //AdapterCaching.Start();
            //GenericValueAdapter.Start();
            //AdapterInDependencyInjection.Start();
            //AdapterCodingExercise.Start();

            // Bridge
            //Bridge.Start();
            //BridgeCodingExercise.Start();

            // Composite
            //GeometricShapes.Start();
            //NeuralNetworks.Start();
            //CompositeSpecification.Start();
            CompositeCodeExcercise.Start();
        }
    }
}
