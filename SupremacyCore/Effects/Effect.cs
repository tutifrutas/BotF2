using System;

using Supremacy.Annotations;
using Supremacy.Scripting;
using Supremacy.Utility;

namespace Supremacy.Effects
{
    [Serializable]
    public abstract class Effect
    {
        public const string ParameterNameSource = "$source";
        public const string ParameterNameTarget = "$target";

        private readonly Lazy<EffectParameterCollection> _systemParameters;
        private readonly Lazy<ScriptParameters> _systemScriptParameters;

        private EffectGroup _effectGroup;

        protected Effect()
        {
            _systemParameters = new Lazy<EffectParameterCollection>(CreateSystemParameters);
            _systemScriptParameters = new Lazy<ScriptParameters>(() => SystemParameters.ToScriptParameters());
        }

        public bool HasDescription
        {
            get { return !string.IsNullOrWhiteSpace(DescriptionExpression); }
        }

        public EffectGroup EffectGroup
        {
            get { return _effectGroup; }
            internal set { _effectGroup = value; }
        }

        public string DescriptionExpression { get; set; }

        public EffectParameterCollection SystemParameters
        {
            get { return _systemParameters.Value; }
        }

        internal ScriptParameters SystemScriptParameters
        {
            get { return _systemScriptParameters.Value; }
        }

        public EffectBinding Bind([NotNull] EffectGroupBinding effectGroupBinding, [NotNull] IEffectTarget effectTarget)
        {
            Guard.ArgumentNotNull(effectGroupBinding, "effectGroupBinding");
            Guard.ArgumentNotNull(effectTarget, "effectTarget"); 

            var binding = BindCore(effectGroupBinding, effectTarget);

            return binding;
        }

        protected abstract EffectBinding BindCore(EffectGroupBinding effectGroupBinding, IEffectTarget effectTarget);

        protected virtual EffectParameterCollection CreateSystemParameters()
        {
            return EffectGroup.SystemParameters;
        }
    }
}