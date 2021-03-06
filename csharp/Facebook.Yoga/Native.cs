﻿/**
 * Copyright (c) 2014-present, Facebook, Inc.
 * All rights reserved.
 *
 * This source code is licensed under the BSD-style license found in the
 * LICENSE file in the root directory of this source tree. An additional grant
 * of patent rights can be found in the PATENTS file in the same directory.
 */

using System;
using System.Runtime.InteropServices;

namespace Facebook.Yoga
{
    internal static class Native
    {
#if (UNITY_IOS && !UNITY_EDITOR) || __IOS__
        private const string DllName = "__Internal";
#else
        private const string DllName = "yoga";
#endif

        internal class YGNodeHandle : SafeHandle
        {
            private YGNodeHandle() : base(IntPtr.Zero, true)
            {
            }

            public override bool IsInvalid
            {
                get
                {
                    return this.handle == IntPtr.Zero;
                }
            }

            protected override bool ReleaseHandle()
            {
                Native.YGNodeFree(this.handle);
                GC.KeepAlive(this);
                return true;
            }
        }

        [DllImport(DllName)]
        public static extern void YGInteropSetLogger(
            [MarshalAs(UnmanagedType.FunctionPtr)] YogaLogger.Func func);

        [DllImport(DllName)]
        public static extern YGNodeHandle YGNodeNew();

        [DllImport(DllName)]
        public static extern void YGNodeFree(IntPtr node);

        [DllImport(DllName)]
        public static extern void YGNodeReset(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern int YGNodeGetInstanceCount();

        [DllImport(DllName)]
        public static extern void YGSetExperimentalFeatureEnabled(
            YogaExperimentalFeature feature,
            bool enabled);

        [DllImport(DllName)]
        public static extern bool YGIsExperimentalFeatureEnabled(
            YogaExperimentalFeature feature);

        [DllImport(DllName)]
        public static extern void YGNodeInsertChild(YGNodeHandle node, YGNodeHandle child, uint index);

        [DllImport(DllName)]
        public static extern void YGNodeRemoveChild(YGNodeHandle node, YGNodeHandle child);

        [DllImport(DllName)]
        public static extern void YGNodeCalculateLayout(YGNodeHandle node,
                            float availableWidth,
                            float availableHeight,
                            YogaDirection parentDirection);

        [DllImport(DllName)]
        public static extern void YGNodeMarkDirty(YGNodeHandle node);

        [DllImport(DllName)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool YGNodeIsDirty(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodePrint(YGNodeHandle node, YogaPrintOptions options);

        [DllImport(DllName)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool YGValueIsUndefined(float value);

        [DllImport(DllName)]
        public static extern void YGNodeCopyStyle(YGNodeHandle dstNode, YGNodeHandle srcNode);

        #region YG_NODE_PROPERTY

        [DllImport(DllName)]
        public static extern void YGNodeSetMeasureFunc(
            YGNodeHandle node,
            [MarshalAs(UnmanagedType.FunctionPtr)] YogaMeasureFunc measureFunc);

        [DllImport(DllName)]
        [return: MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern YogaMeasureFunc YGNodeGetMeasureFunc(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeSetHasNewLayout(YGNodeHandle node, [MarshalAs(UnmanagedType.I1)] bool hasNewLayout);

        [DllImport(DllName)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool YGNodeGetHasNewLayout(YGNodeHandle node);

        #endregion

        #region YG_NODE_STYLE_PROPERTY

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetDirection(YGNodeHandle node, YogaDirection direction);

        [DllImport(DllName)]
        public static extern YogaDirection YGNodeStyleGetDirection(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetFlexDirection(YGNodeHandle node, YogaFlexDirection flexDirection);

        [DllImport(DllName)]
        public static extern YogaFlexDirection YGNodeStyleGetFlexDirection(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetJustifyContent(YGNodeHandle node, YogaJustify justifyContent);

        [DllImport(DllName)]
        public static extern YogaJustify YGNodeStyleGetJustifyContent(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetAlignContent(YGNodeHandle node, YogaAlign alignContent);

        [DllImport(DllName)]
        public static extern YogaAlign YGNodeStyleGetAlignContent(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetAlignItems(YGNodeHandle node, YogaAlign alignItems);

        [DllImport(DllName)]
        public static extern YogaAlign YGNodeStyleGetAlignItems(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetAlignSelf(YGNodeHandle node, YogaAlign alignSelf);

        [DllImport(DllName)]
        public static extern YogaAlign YGNodeStyleGetAlignSelf(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetPositionType(YGNodeHandle node, YogaPositionType positionType);

        [DllImport(DllName)]
        public static extern YogaPositionType YGNodeStyleGetPositionType(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetFlexWrap(YGNodeHandle node, YogaWrap flexWrap);

        [DllImport(DllName)]
        public static extern YogaWrap YGNodeStyleGetFlexWrap(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetOverflow(YGNodeHandle node, YogaOverflow flexWrap);

        [DllImport(DllName)]
        public static extern YogaOverflow YGNodeStyleGetOverflow(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetFlex(YGNodeHandle node, float flex);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetFlexGrow(YGNodeHandle node, float flexGrow);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetFlexGrow(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetFlexShrink(YGNodeHandle node, float flexShrink);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetFlexShrink(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetFlexBasis(YGNodeHandle node, float flexBasis);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetFlexBasis(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetWidth(YGNodeHandle node, float width);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetWidth(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetHeight(YGNodeHandle node, float height);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetHeight(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetMinWidth(YGNodeHandle node, float minWidth);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetMinWidth(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetMinHeight(YGNodeHandle node, float minHeight);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetMinHeight(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetMaxWidth(YGNodeHandle node, float maxWidth);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetMaxWidth(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetMaxHeight(YGNodeHandle node, float maxHeight);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetMaxHeight(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetAspectRatio(YGNodeHandle node, float aspectRatio);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetAspectRatio(YGNodeHandle node);

        #endregion

        #region YG_NODE_STYLE_EDGE_PROPERTY

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetPosition(YGNodeHandle node, YogaEdge edge, float position);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetPosition(YGNodeHandle node, YogaEdge edge);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetMargin(YGNodeHandle node, YogaEdge edge, float margin);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetMargin(YGNodeHandle node, YogaEdge edge);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetPadding(YGNodeHandle node, YogaEdge edge, float padding);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetPadding(YGNodeHandle node, YogaEdge edge);

        [DllImport(DllName)]
        public static extern void YGNodeStyleSetBorder(YGNodeHandle node, YogaEdge edge, float border);

        [DllImport(DllName)]
        public static extern float YGNodeStyleGetBorder(YGNodeHandle node, YogaEdge edge);

        #endregion

        #region YG_NODE_LAYOUT_PROPERTY

        [DllImport(DllName)]
        public static extern float YGNodeLayoutGetLeft(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern float YGNodeLayoutGetTop(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern float YGNodeLayoutGetRight(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern float YGNodeLayoutGetBottom(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern float YGNodeLayoutGetWidth(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern float YGNodeLayoutGetHeight(YGNodeHandle node);

        [DllImport(DllName)]
        public static extern YogaDirection YGNodeLayoutGetDirection(YGNodeHandle node);

        #endregion
    }
}
