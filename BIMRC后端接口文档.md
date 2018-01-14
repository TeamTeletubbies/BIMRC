所有接口为Restful API，所有接口返回数据类型为JSON，所有非GET的接口传入数据类型为JSON。

# 用户注册与管理接口

## POST api/users

注册用户。该接口不需要提供Token。

请求示例与说明：

```json
{
    "Email":"foo@bar.com",//用户的email，同时也是登陆用的用户名
    "Password":"lallla",//用户的密码，明文传输
    "Truename":"高逼逼",//用户的真名
}
```

成功返回值示例与说明：

```json
{
    "Result":"succeed",//注册是否成功
    "UserId":12//注册用户的id
}
```

失败返回示例与说明

```json
{
    "Result":"failed",//注册是否成功
    "Message":"该email已被使用"//错误原因
}
```

## PUT api/users/{userId}

修改密码或名称。注意修改密码后当前的Token会被注销。

请求示例与说明：

```json
{
    "OldPassword":"lallla",//原密码，仅修改名称时留空
    "NewPassword":"lallxxxla",//新密码，仅修改名称是留空
    "TrueName":"咕咕"//新的名称，仅修改密码时留空
}
```

成功返回值示例与说明：

```json
{
    "Result":"succeed",//注册是否成功
}
```

失败返回示例与说明

```json
{
    "Result":"failed",//注册是否成功
    "Message":"该email已被使用"//错误原因
}
```

# 登陆和注销接口

## POST /api/auth

使用邮箱和密码登陆，并获取Token。该接口不需要提供Token。

请求示例与说明：

```json
{
    "Email":"foo@bar.com",//用户的email，同时也是登陆用的用户名
    "Password":"lallla"//用户的密码，明文传输
}
```

成功返回值示例与说明：

```json
{
    "Result":"succeed",//登陆是否成功
    "AcessToken":"adf32gd4t$2jf2rd=",//用户令牌
    "ExpireTime":"2018-01-21 12:20:11",//令牌过期时间
    "TrueName":"高逼逼"//用户的姓名
}
```

失败返回示例与说明

```json
{
    "Result":"failed",//登陆是否成功
    "Message":"该用户不存在"//错误原因
}
```

## DELETE /api/auth

注销用户登陆，销毁当前的Token。

请求中无需参数。

成功返回值示例与说明：

```json
{
    "Result":"succeed"//注销是否成功
}
```

失败返回示例与说明

```json
{
    "Result":"failed",//注销是否成功
    "Message":"令牌无效"//错误原因
}
```

# 项目操作接口

## GET /api/projects

获取当前的所有项目，注意，为了避免数据量过大，此接口并不会返回RCModel和BIMModel。

无请求参数。

返回值示例

```json
[
  {
    "Id": 1,//项目id
    "UserId": 1,//所有者的id
    "ProjName": "sample string 3",//项目名称
    "BucketName": "sample string 4",//项目对应的bucket的名称
    "CreateTime": "2018-01-14T11:47:14.79904+07:00",//项目创建时间
    "BIMModelId":12,//对应的BIMModel的ID
    "thumbnailImage":"http://xxx.xxx/xxx.png"//缩略图的url
  },
  {
    "Id": 2,
    "UserId": 1,
    "ProjName": "sample string 3",
    "BucketName": "sample string 4",
    "CreateTime": "2018-01-14T11:47:14.79904+07:00",
    "BIMModelId":13,
    "thumbnailImage":"http://xxx.xxx/xxx.png"
  }
]
```

## GET /api/projects/{projectID}

获取某个项目的所有详细信息。

无请求参数

返回值示例：

```json
 {
    "Id": 1, //项目ID
    "UserId": 2,//所有者的用户ID
    "ProjName": "sample string 3",//项目名称
    "BIMModel": {//项目对应的BIM模型
      "SVFUrn": "sample string 2",
      "SVFUrn64": "sample string 3",
      "FBXUrn": "sample string 4",
      "FBXUrn64": "sample string 5",
      "SourceName": "sample string 6",
      "Progress": 7.1,
      "Status": 0
    },
    "UsedRCModel": [//项目对应的RC模型
      {
        "Id": 1,
        "DateTime": "2018-01-14T11:47:14.79904+07:00",
        "ProjectId": 3,
        "PhotoSceneId": "sample string 4",
        "Progress": 5.1,
        "Status": 0,
        "ExistId": [
          1,
          2
        ]
      },
      {
        "Id": 1,
        "DateTime": "2018-01-14T11:47:14.79904+07:00",
        "ProjectId": 3,
        "PhotoSceneId": "sample string 4",
        "Progress": 5.1,
        "Status": 0,
        "ExistId": [
          1,
          2
        ]
      }
    ],
    "BucketName": "sample string 4",
    "CreateTime": "2018-01-14T11:47:14.79904+07:00",
  },

```

失败时返回值示例：

```json
{
    "Result":"failed",//创建除是否成功
    "Message":"找不到该项目"//错误原因
}
```



# POST /api/projects

创建新项目的接口。

请求示例

```json
  {
    "ProjName": "sample string 3",//项目名称
  }
```
成功返回值示例与说明：

```json
{
    "Result":"succeed",//创建是否成功
    "Id":2//创建出的项目的ID
}
```

失败返回示例与说明

```json
{
    "Result":"failed",//创建除是否成功
    "Message":"令牌无效"//错误原因
}
```

# PUT /api/projects/{projectId}

修改项目的接口。可修改项目的名称。

请求示例

```json
{
    "ProjName"//新的项目名称
}
```

成功返回值示例与说明：

```json
{
    "Result":"succeed"//修改是否成功
}
```

失败返回示例与说明

```json
{
    "Result":"failed",//修改除是否成功
    "Message":"令牌无效"//错误原因
}
```

# DELETE /api/projects/{prjectId}

删除一个项目，包括与其关联的BIMModel和RCModel。

请求中无需参数。

成功返回值示例与说明：

```json
{
    "Result":"succeed"//删除是否成功
}
```

失败返回示例与说明

```json
{
    "Result":"failed",//删除是否成功
    "Message":"令牌无效"//错误原因
}
```

# BIM模型操作接口

## POST api/bimmodels/{BIMModelId}

上传一个BIM模型。

```json
{
  "ProjectId": 1, //BIM模型对应的项目的ID
  "SVFUrn": "sample string 2", //用于展示的SVF模型的位置
  "FBXUrn": "sample string 4", //用户计算的FBX模型的位置
  "SourceName": "sample string 6", //源文件名
  "Progress": 7.1, //转换进度
  "Status": 0 //当前模型状态
}
```

# 实景模型操作接口

创建一个新的实景模型

```json
{
  "ProjectId": 3, //项目ID 
  "PhotoSceneId": "sample string 4", //Forge上的photoScene的ID
}
```
