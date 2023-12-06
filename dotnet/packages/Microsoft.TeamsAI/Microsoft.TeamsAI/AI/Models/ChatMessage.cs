﻿namespace Microsoft.Teams.AI.AI.Models
{
    /// <summary>
    /// Chat Message
    /// </summary>
    public class ChatMessage
    {
        /// <summary>
        /// The role associated with this message payload.
        /// </summary>
        public ChatRole Role { get; set; }

        /// <summary>
        /// The text associated with this message payload.
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// The name of the author of this message. `name` is required if role is `function`, and it should be the name of the
        /// function whose response is in the `content`. May contain a-z, A-Z, 0-9, and underscores, with a maximum length of
        /// 64 characters.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The name and arguments of a function that should be called, as generated by the model.
        /// </summary>
        public FunctionCall? FunctionCall { get; set; }

        /// <summary> Initializes a new instance of ChatMessage. </summary>
        /// <param name="role"> The role associated with this message payload. </param>
        public ChatMessage(ChatRole role)
        {
            this.Role = role;
        }
    }

    /// <summary>
    /// The name and arguments of a function that should be called, as generated by the model.
    /// </summary>
    public class FunctionCall
    {
        /// <summary>
        /// The name of the function to call.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The arguments to call the function with, as generated by the model in JSON format.
        /// Note that the model does not always generate valid JSON, and may hallucinate parameters
        /// not defined by your function schema. Validate the arguments in your code before calling
        /// your function.
        /// </summary>
        public string Arguments { get; set; }

        /// <summary>
        /// Creates an instance of `FunctionCall`.
        /// </summary>
        /// <param name="name">function name</param>
        /// <param name="arguments">function arguments</param>
        public FunctionCall(string name, string arguments)
        {
            this.Name = name;
            this.Arguments = arguments;
        }
    }
}
