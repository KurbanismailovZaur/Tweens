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

        IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            
            var tween = new Tween<float, FloatTweak>("tween0", 0f, 1f, _target0.SetPositionX, 1f, Formula.Linear, 1, LoopType.Reset, Direction.Forward);

            //var seq = new Sequence("seq", Formula.Linear, 2, LoopType.Continue);
            //seq.Append(tween0);

            SubscribeOnAllEvents(tween);
            //SubscribeOnAllEvents(seq);

            tween.Play();

            //yield return seq.Play().WaitForComplete();
            //yield return new WaitForSeconds(1f);
            //seq.PlayBackward();
            //seq.SkipToEnd().PlayBackward();
        }
    }

    //class ResearchTeam
    //{
    //    public int PersonsCount => UnityEngine.Random.Range(1, 3);
    //}

    //// Просто создаю 5 researchTeam с произвольным количеством участников
    //var researchTeams = Enumerable.Range(0, 5).Select(i => new ResearchTeam());

    //// Условно n - это сколько участников должно быть в группе.
    //var n = 3;

    //// Группируем researchTeam по количеству их участников
    //var groupsByPersonsCount = researchTeams.GroupBy(rt => rt.PersonsCount);

    //// затем берем только те группы где количество участников = n (метод Where)
    //var groupsWherePersonsCountEqualsToN = groupsByPersonsCount.Where(rt => rt.Key == n);

    //// но мы знаем, что там будет только 1 группа, поэтому мы вызываем метод First, который вернет эту единственную группу
    //var firstGroup = groupsWherePersonsCountEqualsToN.First();

    //// а затем, у этой группы я вызываю ToList, который преобразует эту группу в список из ResearchTeam.
    //List<ResearchTeam> listOfResearchTeamsOfThisGroup = firstGroup.ToList();
}