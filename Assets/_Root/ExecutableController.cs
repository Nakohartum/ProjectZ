using System;
using System.Collections.Generic;
using _Root.Interfaces;

namespace _Root
{
    public class ExecutableController : IExecutable, ILateExecutable, IFixedExecutable, IDisposable
    {
        private List<IExecutable> _executables;
        private List<IFixedExecutable> _fixedExecutables;
        private List<ILateExecutable> _lateExecutables;

        public ExecutableController()
        {
            _executables = new List<IExecutable>();
            _fixedExecutables = new List<IFixedExecutable>();
            _lateExecutables = new List<ILateExecutable>();
        }

        public void AddExecutable(IExecutable executable)
        {
            _executables.Add(executable);
        }

        public void RemoveExecutable(IExecutable executable)
        {
            _executables.Remove(executable);
        }

        public void AddFixedExecutable(IFixedExecutable executable)
        {
            _fixedExecutables.Add(executable);
        }

        public void RemoveFixedExecutable(IFixedExecutable executable)
        {
            _fixedExecutables.Remove(executable);
        }

        public void AddLateExecutable(ILateExecutable executable)
        {
            _lateExecutables.Add(executable);
        }

        public void RemoveLateExecutable(ILateExecutable executable)
        {
            _lateExecutables.Remove(executable);
        }

        
        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _executables.Count; i++)
            {
                _executables[i].Execute(deltaTime);
            }
        }

        public void FixedExecute(float fixedTime)
        {
            for (int i = 0; i < _fixedExecutables.Count; i++)
            {
                _fixedExecutables[i].FixedExecute(fixedTime);
            }
        }
        
        public void LateExecute()
        {
            for (int i = 0; i < _lateExecutables.Count; i++)
            {
                _lateExecutables[i].LateExecute();
            }
        }

        public void Dispose()
        {
            _executables.Clear();
            _fixedExecutables.Clear();
            _lateExecutables.Clear();
        }
    }
}