# What to improve

- Make reducers scoped to a Type (A reducer for a subState of the MainState)
	- Maybe add better Selector Support to "fix" this -> no
	- public ref T Selector\<T>() -> does not comp

- BindToCollection needs to support getting more state. For Message.Id + ":" + User.Id cus of trackBy
- Must Fix ref stuff in struct (Arrays/Dicts)