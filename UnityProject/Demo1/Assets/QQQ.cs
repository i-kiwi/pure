using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class QQQ : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//这两步先加载数据，一个骨骼、一个纹理；Dragon/Dragon_ske替换成你的动画文件名
        UnityFactory.factory.LoadDragonBonesData("/Resources/DragonDemo/DragonDemo_ske"); // DragonBones file path (without suffix)
        UnityFactory.factory.LoadTextureAtlasData("/Resources/DragonDemo/DragonDemo_tex"); //Texture atlas file path (without suffix) 
              //这里构建动画，Dragon替换成你要构建的动画角色名
        var armature =UnityFactory.factory.BuildArmatureComponent("Armature"); // Input armature name
        // 播放动画，walk替换成你需要的动画名
		armature.animation.animationConfig.playTimes = 10;
        armature.animation.Play("stand");

        // Change armatureposition.
        armature.transform.localPosition = new Vector2(0.0f, 0.0f);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
