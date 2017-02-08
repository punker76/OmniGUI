﻿namespace OmniGui.Xaml
{
    using System;
    using System.Reactive.Linq;
    using System.Reflection;
    using OmniXaml;

    public class OmniGuiXamlBuilder : ExtendedObjectBuilder
    {
        public OmniGuiXamlBuilder(IInstanceCreator creator, ObjectBuilderContext objectBuilderContext,
            IContextFactory contextFactory) : base(creator, objectBuilderContext, contextFactory)
        {
        }

        protected override void PerformAssigment(Assignment assignment, BuildContext buildContext)
        {
            var bd = assignment.Value as ObserveDefinition;
            if (bd != null)
            {
                BindToObservable(bd);
            }
            else
            {
                base.PerformAssigment(assignment, buildContext);
            }
        }

        private static void BindToObservable(ObserveDefinition assignment)
        {
            var targetObj = (Layout) assignment.TargetInstance;
            var obs = targetObj.GetChangedObservable(Layout.DataContextProperty);
            obs.Where(o => o != null)
                .Subscribe(context =>
                {
                    BindSourceToTarget(assignment, context, targetObj);
                    //BindTargetToSource(assignment, context, targetObj);
                });
        }

        private static void BindSourceToTarget(ObserveDefinition assignment, object context, Layout targetObj)
        {
            var sourceProp = context.GetType().GetRuntimeProperty(assignment.ObservableName);
            var sourceObs = (IObservable<object>) sourceProp.GetValue(context);
            var targetProperty = targetObj.GetProperty(assignment.AssignmentMember.MemberName);
            var observer = targetObj.GetObserver(targetProperty);

            sourceObs.Subscribe(observer);
        }

        private static void BindTargetToSource(ObserveDefinition assignment, object context, Layout targetObj)
        {
            var sourceProp = context.GetType().GetRuntimeProperty(assignment.ObservableName);
            var sourceObs = (IObserver<object>) sourceProp.GetValue(context);
            var targetProperty = targetObj.GetProperty(assignment.AssignmentMember.MemberName);
            var observer = targetObj.GetChangedObservable(targetProperty);

            observer.Subscribe(sourceObs);
        }
    }
}