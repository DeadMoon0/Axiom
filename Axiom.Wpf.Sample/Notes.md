# What to improve

- Make reducers scoped to a Type (A reducer for a subState of the MainState)
	- Maybe add better Selector Support to "fix" this -> no
	- public ref T Selector\<T>() -> does not comp

- BindToCollection needs to support getting more state. For Message.Id + ":" + User.Id cus of trackBy
- Must Fix ref stuff in struct (Arrays/Dicts)

- [x] StateActionsAsync
	- To Help with the common Load, LoadSuccess, LoadError Schema
	- Also to make this schema a first party thing
	```
	StateActionAsync.BeginAction
	StateActionAsync.SuccessAction
	StateActionAsync.ErrorAction
	```

- [x] Reducer-Scopes
	- To Help with the Reducer Selector overhead in SubReducer
	```
	Scope(selector)
		.On()
		.On()
		.On()
	```