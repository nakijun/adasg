/*

Copyright (C) 2004 XrossOne Studio (www.xrossone.com), All rights reserved.
Author : Xinjie ZHANG (xjzhang@xrossone.com)

This license governs use of the accompanying software ("Software"), and your use
of the Software constitutes acceptance of this license.

You may use the Software for any commercial or noncommercial purpose, including
distributing derivative works.

In return, we simply require that you agree:
1.	Not to remove any copyright or other notices from the Software.
2.	That if you distribute the Software in source code form you do so only under
this license (i.e. you must include a complete copy of this license with your
distribution), and if you distribute the Software solely in object form you only
do so under a license that complies with this license.
3.	That the Software comes "as is", with no warranties. None whatsoever. This
means no express, implied or statutory warranty, including without limitation,
warranties of merchantability or fitness for a particular purpose or any
warranty of title or non-infringement. Also, you must pass this disclaimer on
whenever you distribute the Software or derivative works.
4.	That XrossOne Studio will be liable for any of those types of damages known 
as indirect, special, consequential, or incidental related to the Software or this
license, to the maximum extent the law permits, no matter what legal theory it's
based on. Also, you must pass this limitation of liability on whenever you distribute 
the Software or derivative works.
5.	That if you sue anyone over patents that you think may apply to the Software
for a person's use of the Software, your license to the Software ends
automatically.
6.	That the patent rights, if any, granted in this license only apply to the
Software, not to any derivative works you make.
7.	That your rights under this License end automatically if you breach it in
any way.
8.	That all rights not expressly granted to you in this license are reserved.

*/

using System;
namespace XrossOne.DrawingFP
{
	
	
	public interface GraphicsPathIterator
	{
		void  Begin();
		void  End();
		
		void  MoveTo(PointFP point);
		void  LineTo(PointFP point);
		void  CurveTo(PointFP control, PointFP point);
		void  CurveTo(PointFP control1, PointFP control2, PointFP point);
		void  Close();
	}
}