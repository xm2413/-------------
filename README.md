# personal Finance System

### 警告！

只支持**SQLServer**使用！其他数据库（比如pg）如果出问题暂无解决方案！

### 使用教程

1. 打开**SQLManager.cs**，找到开头的connectionString，修改成你自己的。之后即可使用。

##### 小提示：

1. 里面有个SQLManager类单例，你可以改一下connectionString就直接用
   - 包含了在item，list，category的列表中按照id或name查询某一值的方法
   - 以及从数据库中一键获取item，list，category的方法
2. 遇到不懂**先查再问**，**先问AI再问我**。程序有问题请提交issue
3. 请独立完成作业

```
V1.0：yuanzip制作
v1.1: 增加代码可读性，解决了部分报错问题；（感谢happyFairy提供修改）
v1.2：整合了所有connectionString。解决了user的账户名问题，解决了其他各种报错。
```

