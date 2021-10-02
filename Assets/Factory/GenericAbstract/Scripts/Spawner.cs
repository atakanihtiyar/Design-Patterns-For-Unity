using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.GenericAbstractFactory
{
    internal class Spawner : MonoBehaviour
    {
        private void Start()
        {
            PersonalComputer personalComputer = SpawnPersonalComputer();
            Debug.Log("Personal Computer\nRam capacity: " + personalComputer.ram.capacity + "gb - Processor speed: " + personalComputer.processor.speed + "Ghz - Monitor size: " + personalComputer.monitor.size + " inch");
            personalComputer.processor.Operate();

            MicroController controller = SpawnMicroController();
            Debug.Log("Microcontroller\nRam capacity: " + controller.ram.capacity + "kb - Processor speed: " + controller.processor.speed + "Mhz");
            controller.ram.Operate();
        }

        private PersonalComputer SpawnPersonalComputer()
        {
            GameObject obj = new GameObject("Personal Computer");

            MainFactory<PersonalComputerFactory> computerFactory = new MainFactory<PersonalComputerFactory>();
            PersonalComputer computer = computerFactory.Assemble<PersonalComputer>(obj);

            computer.ram = computerFactory.Assemble<Ram>(obj);
            computer.ram.capacity = 16;

            computer.processor = computerFactory.Assemble<Processor>(obj);
            computer.processor.speed = 3.6f;

            computer.monitor = computerFactory.Assemble<Monitor>(obj);
            computer.monitor.size = 22;

            return computer;
        }

        private MicroController SpawnMicroController()
        {
            GameObject obj = new GameObject("MicroController");

            MainFactory<MicroControllerFactory> controllerFactory = new MainFactory<MicroControllerFactory>();
            MicroController controller = controllerFactory.Assemble<MicroController>(obj);

            controller.ram = controllerFactory.Assemble<Ram>(obj);
            controller.ram.capacity = 2;

            controller.processor = controllerFactory.Assemble<Processor>(obj);
            controller.processor.speed = 16f;

            return controller;
        }
    }
}
