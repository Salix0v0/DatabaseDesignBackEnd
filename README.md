# DatabaseDesign
## 拉取仓库到本地
- 先拉取后端仓库```DatabaseDesignBackEnd```
- cd vueapp
- 再拉取前端仓库```DatabaseDesignFrontEnd```
## 运行程序
### 运行后端
- vs打开```CarManagement.sln```
- 右键webapi/依赖项，下载NuGet程序包```Oracle.ManagedDataAccess.Core```
- 确保已经打开Oracle服务
- 选择webapi作为启动项目，运行
### 运行前端
- 先启动后端
- cd vueapp
- npm install(有node_modules就不需要运行了，除非又添加了新的库)
- npm run serve
