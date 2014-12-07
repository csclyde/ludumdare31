﻿using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	protected NavMeshAgent _agent;
	protected Transform _target; 
	protected UnitManager _manager;
	protected bool _play; 



	public void Pause(){
		_agent.Stop ();
		_play = false; 
	}
	public void Play(){
		_agent.Resume ();
		_play = true; 
	}
	public virtual void GoHere(Vector3 _destination){
		_target.position = _destination; 
		_agent.destination = _target.position; 
	}
	protected virtual void AddToList(){
		_manager.AddToLists (this);
	}
	protected virtual void Died(){
		_manager.Died (this); 
		Destroy (gameObject); 
	}
	void Start(){
		_agent = GetComponent<NavMeshAgent> (); 
		_target = new GameObject ().GetComponent<Transform> (); 
		_target.name = this.name + "-Target"; 
		_manager = GameObject.Find ("GameController").GetComponent<UnitManager> (); 

		AddToList (); 
	}
	void Update(){
		
	}

	/*
	public GameObject MakePipes(GameObject _startObject, GameObject _endObject, Object _pipe){
		Vector3 _direction = (_endObject.transform.position - _startObject.transform.position).normalized; //get the direction of the pieps
		float _distance = Vector3.Distance (_startObject.transform.position, _endObject.transform.position);  //how far are they?
		GameObject pipeParent = new GameObject ();  //make the parent object
		pipeParent.transform.position = _startObject.transform.position + _distance * .5f * _direction; // put it in the middle

		float _laidPipeDistance = 0; 
		float _pipeLength = 0; 
		while (_laidPipeDistance < _distance) { //this will keep making pipe, till you've reached your destination
			GameObject _thePipe = Instantiate(_pipe) as GameObject; 
			if(_pipeLength == 0){
				_pipeLength = _thePipe.renderer.bounds.size.z; //this may be the wrong axis, will need checking
			}
			_thePipe.transform.forward = _direction; //have it look towards the end position
			_thePipe.transform.position = _startObject.transform.position + _direction * _pipeLength; //tells it where to be
			_thePipe.transform.parent = pipeParent.transform; 
			_laidPipeDistance += _pipeLength; 
		}
		return pipeParent; 
	}
	*/




}
