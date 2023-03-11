## Adobe Gradient Picker Clone

![1](https://user-images.githubusercontent.com/65526236/224451228-3a5d4686-1e1a-4e22-aa61-d2415f8d41a7.PNG)

![2](https://user-images.githubusercontent.com/65526236/224451234-57687773-ed85-4b40-9114-6f18b84fd8c8.PNG)

<h2>Introduction</h2>

> Whenever designing a graphic editor, a lot of effort is about usability. The way how controls react to the user heavily influences how artists work with your application. And each time you change the workflow, the users have to re-adapt the functionality.

> So why always start from scratch when designing graphical controls? Over the years, Adobe(r) Photoshop has become some kind of industry standard in how graphic editors work. And this article brings the gradient editing ability to your standard .NET LinearGradient- and PathGradient-Brushes.

<h2>Background</h2>

> Basically there are two usual ways of modelling the gradient stops. The first way which is also how Adobe Illustrator's gradients are handled, is the following:

![illustrator_gradient](https://user-images.githubusercontent.com/65526236/224450845-ce52c1de-9b02-435a-9dc9-d8291bc06a0e.png)

> Here, each gradient stop has a position (0-100%) and an opacity-value associated
to it. This way, Color and Alpha are specifically to each gradient stop.

> The other way is treating gradients like Adobe Photoshop:

![photoshop_gradient](https://user-images.githubusercontent.com/65526236/224450880-7df66e01-1ec1-419d-99e1-e324be6fa2eb.png)

> Here, the Color- and Alpha- gradients are separated, making it easy to apply various different patterns that are more difficult to create in Illustrator.

> So, I decided to implement my gradient manager the second way. But the problem is that .NET GDI+ wrapper cannot handle separated color and alpha gradients. Only Colors with alpha channels can be put on a ColorBlend-object, making only the first implementation possible...

> Notice the call to FocusToBalance, which processes gradient stops that have a modified center focus value, like this:

![focus](https://user-images.githubusercontent.com/65526236/224450957-05101e0e-c1ce-4795-9b87-eaa2dd6706bb.png)

> That is basically a modification of the interpolation function, which is linear here:

![focus-interpolation](https://user-images.githubusercontent.com/65526236/224451009-ca1f8156-32fa-476f-ae67-501e842f87fa.png)

<h2>GradientEdit Controls</h2>

> As the main purpose of this class is not to allow simple gradient creation in code, which is in fact much simpler by using standard colorblend objects, but to create a user control for this purpose, there are several controls which can be used on any user interface:

![gradientedit](https://user-images.githubusercontent.com/65526236/224451143-0c336e62-3eb3-4967-bd2d-aac1fb2b533b.png)

> GradientEdit is the editing control for one single gradient object, and has events for selectionchange.
> Stops can be created by clicking into a free area, and deleted by dragging them outside the control area.

![gradienteditpanel](https://user-images.githubusercontent.com/65526236/224451178-1b7f4377-3383-4f3c-bffe-938497f179b2.png)
