using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Data;

namespace Axiom.Wpf.Extensions;

public static class BindToElementExtension
{
    private class NotifyPropertyChangedProxy :
     INotifyPropertyChanged,
     ICustomTypeDescriptor
    {
        private readonly PropertyDescriptorCollection _properties;
        private object? _value;

        public NotifyPropertyChangedProxy(string propertyName, Type propertyType)
        {
            _properties = new PropertyDescriptorCollection(
            [
                new DynamicPropertyDescriptor(propertyName, propertyType)
            ]);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public object? Value
        {
            get => _value;
            set
            {
                _value = value;
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(_properties[0].Name));
            }
        }


        #region ICustomTypeDescriptor

        public PropertyDescriptorCollection GetProperties() => _properties;
        public PropertyDescriptorCollection GetProperties(Attribute[]? attributes) => _properties;

        public AttributeCollection GetAttributes() => AttributeCollection.Empty;
        public string? GetClassName() => GetType().Name;
        public string? GetComponentName() => null;
        public TypeConverter GetConverter() => TypeDescriptor.GetConverter(this);
        public EventDescriptor? GetDefaultEvent() => null;
        public PropertyDescriptor? GetDefaultProperty() => null;
        public object? GetEditor(Type editorBaseType) => null;
        public EventDescriptorCollection GetEvents() => EventDescriptorCollection.Empty;
        public EventDescriptorCollection GetEvents(Attribute[]? attributes) => EventDescriptorCollection.Empty;
        public object GetPropertyOwner(PropertyDescriptor? pd) => this;

        #endregion
    }

    private class DynamicPropertyDescriptor : PropertyDescriptor
    {
        private readonly Type _type;

        public DynamicPropertyDescriptor(string name, Type type)
            : base(name, null)
        {
            _type = type;
        }

        public override Type PropertyType => _type;
        public override Type ComponentType => typeof(NotifyPropertyChangedProxy);
        public override bool IsReadOnly => false;

        public override object? GetValue(object? component)
            => ((NotifyPropertyChangedProxy?)component)?.Value;

        public override void SetValue(object? component, object? value)
        {
            if (component is null) return;
            ((NotifyPropertyChangedProxy)component).Value = value;
        }

        public override bool CanResetValue(object component) => false;
        public override void ResetValue(object component) { }
        public override bool ShouldSerializeValue(object component) => false;
    }

    public static IDisposable BindToElement<T>(this IObservable<T> observable, string propertyName, FrameworkElement element, DependencyProperty property)
    {
        Binding binding = new Binding(propertyName);
        NotifyPropertyChangedProxy proxy = new NotifyPropertyChangedProxy(propertyName, typeof(T));
        binding.Source = proxy;
        element.SetBinding(property, binding);

        return observable.Subscribe(next => proxy.Value = next);
    }

    public static IDisposable BindToElement<T>(this IObservable<T> observable, FrameworkElement element, DependencyProperty property)
    {
        string propertyName = "Prop" + new Random().Next(1000, 10000);
        Binding binding = new Binding(propertyName);
        NotifyPropertyChangedProxy proxy = new NotifyPropertyChangedProxy(propertyName, typeof(T));
        binding.Source = proxy;
        element.SetBinding(property, binding);

        return observable.Subscribe(next => proxy.Value = next);
    }
}