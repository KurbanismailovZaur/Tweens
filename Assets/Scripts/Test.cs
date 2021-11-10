using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
using Coroutines;
using Coroutines.Extensions;
using Object = UnityEngine.Object;
using Coroutine = Coroutines.Coroutine;
using Tweens.Tweaks;
using Tweens;
using Tweens.Formulas;

namespace Tweens
{
    public class Test : MonoBehaviour
    {
        [SerializeField]
        private Transform _target0;

        [SerializeField]
        private Transform _target1;

        [SerializeField]
        private Transform _target2;

        [SerializeField]
        private Transform _target3;

        [SerializeField]
        private Transform _target4;

        [SerializeField]
        private Transform _target5;

        [SerializeField]
        private Transform _target6;

        [SerializeField]
        private Transform _target7;

        private void SubscribeOnAllEvents(IPlayable<Playable> playable)
        {
            playable.OnPhaseStarting((p, dir) => print($"[{p.Name}] Phase starting in {dir} direction"));
            playable.OnPhaseStarted((p, dir) => print($"[{p.Name}] Phase started in {dir} direction"));
            playable.OnPhaseLoopStarting((p, li, dir) => print($"[{p.Name}] Phase loop {li} starting in {dir} direction"));
            playable.OnPhaseLoopStarted((p, li, dir) => print($"[{p.Name}] Phase loop {li} started in {dir} direction"));
            playable.OnPhaseUpdating((p, t, dir) => print($"[{p.Name}] Phase updating {t} time in {dir} direction"));
            playable.OnPhaseUpdated((p, t, dir) => print($"[{p.Name}] Phase updated {t} time in {dir} direction"));
            playable.OnPhaseLoopUpdating((p, li, lt, dir) => print($"[{p.Name}] Phase loop {li} updating {lt} time in {dir} direction"));
            playable.OnPhaseLoopUpdated((p, li, lt, dir) => print($"[{p.Name}] Phase loop {li} updated {lt} time in {dir} direction"));
            playable.OnPhaseLoopCompleting((p, li, dir) => print($"[{p.Name}] Phase loop {li} completing in {dir} direction"));
            playable.OnPhaseLoopCompleted((p, li, dir) => print($"[{p.Name}] Phase loop {li} completed in {dir} direction"));
            playable.OnPhaseCompleting((p, dir) => print($"[{p.Name}] Phase completing in {dir} direction"));
            playable.OnPhaseCompleted((p, dir) => print($"[{p.Name}] Phase completed in {dir} direction"));
        }

        void Start()
        {
            Coroutine.Run(RotateEnumerable());
        }

        IEnumerable RotateEnumerable()
        {
            var targetZ = transform.eulerAngles.z + 180f;

            while (transform.eulerAngles.z < targetZ)
            {
                transform.Rotate(0f, 0f, 90f * Time.deltaTime);
                yield return null;
            }

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, targetZ);
        }
    }
}

//public class Person : IComparable<Person>
//{
//    private DateTime _birthday;

//    public int CompareTo(Person other) => _birthday.CompareTo(other._birthday);
//}

//public class PersonComparer : IComparer<Person>
//{
//    public int Compare(Person first, Person second) => first.CompareTo(second);
//}

//_students.Sort(new PersonComparer());