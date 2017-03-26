2017/03/25

目前我取的名是scripts綁在跟prefabs一樣的名字上面

==============================
Prefabs:

ObjectPooler
	管理子彈生成的空物件

BulletTest
	基礎子彈,綁 BulletBehavior

BulletParent BulletParent2 BulletChild TurretParent TurretParent2
	子母彈,BulletParent 消失後生成 TurretParent 發射 BulletParent2
	BulletParent2 消失後生成 TurretParent2 發射 BulletChild

BulletRotate 
	會轉彎的子彈

TurretDefault
	基礎砲塔,綁 TurretBehaviour

TurretNWay
	生成 NxN 個方向的砲塔

TurretSpherical
	球形隨機生成子彈點

TurretParentChild
	發射第一發子母彈的砲塔

TurretUnknown
	不明殘留物

MovingCube
	來回移動的方塊,暫定的測試 target

==============================
Scripts:

BulletBehavior
	子彈的基礎行為

BulletParent BulletChild
	子母彈,暫時拉出來讓子母彈有獨立的行為

BulletRotate
	旋轉的子彈

BulletUnknown
	不明殘留物子彈

TurretBehaviour
	砲塔的基礎行為

TurretChild
	子母彈上面生成子彈的點

TurretParent
	控制子母彈生成砲塔的位置

TurretUnknown
	不明殘留物
==============================
Temp
未完成的暫時資料夾	