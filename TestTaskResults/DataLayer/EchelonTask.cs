using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kontur.Core.Binary.Serialization;
using Kontur.Utilities;
using Newtonsoft.Json;

namespace Kontur.Echelon
{
	/// <summary>
	/// A class for configuring tasks.
	/// It extends two interfaces: IBinarySerializable and IEnumerable<KeyValuePair<string, string>>
	/// </summary>
    [JsonObject]
    public class EchelonTask : IBinarySerializable, IEnumerable<KeyValuePair<string, string>>
    {
       
		/// <summary>
	    /// A constructor that takes string type and IDictionary<string, string> content as parameters and passes them to the base constructor.
		/// </summary>
        public EchelonTask(string type, IDictionary<string, string> content)
            : this(Guid.NewGuid(), type, content)
        {
        }

		/// <summary>
		/// A constructor that takes Guid id and string type as parameters and passes them to the base constructor.
		/// </summary>
        public EchelonTask(Guid id, string type)
            : this(id, type, new Dictionary<string, string>())
        {
        }

		/// <summary>
		/// A constructor that takes string type as a parameter and passes it to the base constructor.
		/// </summary>
        public EchelonTask(string type)
            : this(type, new Dictionary<string, string>())
        {
        }

		/// <summary>
		/// A base constructor that takes Guid id, string type and IDictionary<string, string> content and assignes them to the corresponding properties of the class.
		/// </summary>
        [JsonConstructor]
        internal EchelonTask(Guid id, string type, IDictionary<string, string> content)
        {
            Id = id;
            Type = type;
            Content = content;
        }

		/// <summary>
		/// A property that provides the current task id.
		/// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; private set; }

		/// <summary>
		/// A property that provides the current task type.
		/// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; private set; }

		/// <summary>
		/// A property that provides the current task's Content.
		/// </summary>
        [JsonProperty(PropertyName = "content", Required = Required.Always)]
        public IDictionary<string, string> Content { get; private set; }

		/// <summary>
		/// Provides an indexer for Content.
		/// </summary>
        public string this[string key]
        {
            get { return Content[key]; }
        }

		/// <summary>
		///  Adds a new element to Content.
		/// </summary>
        public void Add(string key, string value)
        {
            Content.Add(key, value);
        }
		
		/// <summary>
		/// Returns a Content enumerator.
		/// </summary>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return Content.GetEnumerator();
        }

		/// <summary>
		/// Overrides a generic toString() method.
		/// </summary>
        public override string ToString()
        {
            return string.Format("id: {0}, type: {1}, content: {2}", Id, Type, SerializationHelper.SerializeToJsonLine(Content));
        }

		/// <summary>
		/// Returns a Content enumerator.
		/// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

      
    }
}
