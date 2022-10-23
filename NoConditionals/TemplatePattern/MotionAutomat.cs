using System;
using System.Diagnostics;

namespace NoConditionals.TemplatePattern
{
    internal class MotionAutomat
    {
        private int currentPosition = 0;

 //ale jeto divny, ocekaval jsem ze to vypise nejdriv 1. hlasku a pak druhou, ale po n2jakem koukani to asi delat nemelo
 //mohl bzch to duelat dvema classama, ale to me nenapadlo a chci to prodiskutovat
        public void UpdatePosition(int increment)
        {
            var motion = SelectClass(increment);

            motion.ApplyAction();
            this.currentPosition += increment;
            motion.ApplyAction();

        }

        internal void ApplyAction(string message)
        {
            Debug.WriteLine("New position is: '{0}' ({1}).", this.currentPosition, message);
        }

        internal IMotionAutomat SelectClass(int increment)
        {
            if (increment <= 5)
                return new ClassLess5(this);

            return new ClassMore5(this);
        }

    }


    internal interface IMotionAutomat
    {
        void ApplyAction();
    }

    internal class ClassLess5 : IMotionAutomat
    {
        private MotionAutomat motionAutomat;
        public ClassLess5(MotionAutomat ma)
        {
            this.motionAutomat = ma;
        }

        void IMotionAutomat.ApplyAction()
        {
            this.motionAutomat.ApplyAction("Increase sensor sensitivity");
        }
    }

    internal class ClassMore5 : IMotionAutomat
    {
        private MotionAutomat motionAutomat;
        public ClassMore5(MotionAutomat ma)
        {
            this.motionAutomat = ma;
        }

        void IMotionAutomat.ApplyAction()
        {
            this.motionAutomat.ApplyAction("Enable secondary break sensor.");
        }
    }
}

