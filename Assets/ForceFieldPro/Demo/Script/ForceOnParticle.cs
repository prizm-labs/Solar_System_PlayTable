using UnityEngine;
using System.Collections;

/// <summary>
/// Attach this script on a particle system.
/// All its and its children's particles will be affected by the target force field.
/// </summary>
public class ForceOnParticle : MonoBehaviour
{
    [FFToolTip("The force field that will be used.")]
    public ForceField smallweight;
	public ForceField midweight;
	public ForceField largeweight;
	public ForceField osc_weight;
	public ForceField repel_weight;

    [FFToolTip("Modifier of the force.")]
    public float factor = 1;

    ParticleEmitter[] pes;
    ParticleSystem[] pss;

    // Use this for initialization
    void Start()
    {
        pes = GetComponentsInChildren<ParticleEmitter>(true);
        pss = GetComponentsInChildren<ParticleSystem>(true);
    }

    void Update()
    {
		if (smallweight != null && smallweight.gameObject.activeSelf) {
				foreach (ParticleEmitter pe in pes) {
					Transform t = pe.transform;
					Particle[] particles = pe.particles;
					int num = particles.Length;
					for (int i = 0; i < num; i++) {
						Vector3 force;
						if (!pe.useWorldSpace) {
						force = t.InverseTransformDirection (smallweight.GetForce (t.TransformPoint (particles [i].position)));
						} else {
						force = smallweight.GetForce (particles [i].position);
						}
						particles [i].velocity += force * factor;
					}
					pe.particles = particles;
				}
				foreach (ParticleSystem ps in pss) {
					Transform t = ps.transform;
					ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.maxParticles];
					int num = ps.GetParticles (particles);
					for (int i = 0; i < num; i++) {
						Vector3 force;
						if (ps.simulationSpace == ParticleSystemSimulationSpace.Local) {
						force = t.InverseTransformDirection (smallweight.GetForce (t.TransformPoint (particles [i].position)));
						} else {
						force = smallweight.GetForce (particles [i].position);
						}
						particles [i].velocity += force * factor;
					}
					ps.SetParticles (particles, num);
				}
			}
		if (midweight != null && midweight.gameObject.activeSelf ) {
			foreach (ParticleEmitter pe in pes) {
				Transform t = pe.transform;
				Particle[] particles = pe.particles;
				int num = particles.Length;
				for (int i = 0; i < num; i++) {
					Vector3 force;
					if (!pe.useWorldSpace) {
						force = t.InverseTransformDirection (midweight.GetForce (t.TransformPoint (particles [i].position)));
					} else {
						force = midweight.GetForce (particles [i].position);
					}
					particles [i].velocity += force * factor;
				}
				pe.particles = particles;
			}
			foreach (ParticleSystem ps in pss) {
				Transform t = ps.transform;
				ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.maxParticles];
				int num = ps.GetParticles (particles);
				for (int i = 0; i < num; i++) {
					Vector3 force;
					if (ps.simulationSpace == ParticleSystemSimulationSpace.Local) {
						force = t.InverseTransformDirection (midweight.GetForce (t.TransformPoint (particles [i].position)));
					} else {
						force = midweight.GetForce (particles [i].position);
					}
					particles [i].velocity += force * factor;
				}
				ps.SetParticles (particles, num);
			}
		}
		if (largeweight != null && largeweight.gameObject.activeSelf) {
			foreach (ParticleEmitter pe in pes) {
				Transform t = pe.transform;
				Particle[] particles = pe.particles;
				int num = particles.Length;
				for (int i = 0; i < num; i++) {
					Vector3 force;
					if (!pe.useWorldSpace) {
						force = t.InverseTransformDirection (largeweight.GetForce (t.TransformPoint (particles [i].position)));
					} else {
						force = largeweight.GetForce (particles [i].position);
					}
					particles [i].velocity += force * factor;
				}
				pe.particles = particles;
			}
			foreach (ParticleSystem ps in pss) {
				Transform t = ps.transform;
				ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.maxParticles];
				int num = ps.GetParticles (particles);
				for (int i = 0; i < num; i++) {
					Vector3 force;
					if (ps.simulationSpace == ParticleSystemSimulationSpace.Local) {
						force = t.InverseTransformDirection (largeweight.GetForce (t.TransformPoint (particles [i].position)));
					} else {
						force = largeweight.GetForce (particles [i].position);
					}
					particles [i].velocity += force * factor;
				}
				ps.SetParticles (particles, num);
			}
		}
		if (osc_weight != null && osc_weight.gameObject.activeSelf) {
			foreach (ParticleEmitter pe in pes) {
				Transform t = pe.transform;
				Particle[] particles = pe.particles;
				int num = particles.Length;
				for (int i = 0; i < num; i++) {
					Vector3 force;
					if (!pe.useWorldSpace) {
						force = t.InverseTransformDirection (osc_weight.GetForce (t.TransformPoint (particles [i].position)));
					} else {
						force = osc_weight.GetForce (particles [i].position);
					}
					particles [i].velocity += force * factor;
				}
				pe.particles = particles;
			}
			foreach (ParticleSystem ps in pss) {
				Transform t = ps.transform;
				ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.maxParticles];
				int num = ps.GetParticles (particles);
				for (int i = 0; i < num; i++) {
					Vector3 force;
					if (ps.simulationSpace == ParticleSystemSimulationSpace.Local) {
						force = t.InverseTransformDirection (osc_weight.GetForce (t.TransformPoint (particles [i].position)));
					} else {
						force = osc_weight.GetForce (particles [i].position);
					}
					particles [i].velocity += force * factor;
				}
				ps.SetParticles (particles, num);
			}
		}
		if (repel_weight != null && repel_weight.gameObject.activeSelf) {
			foreach (ParticleEmitter pe in pes) {
				Transform t = pe.transform;
				Particle[] particles = pe.particles;
				int num = particles.Length;
				for (int i = 0; i < num; i++) {
					Vector3 force;
					if (!pe.useWorldSpace) {
						force = t.InverseTransformDirection (repel_weight.GetForce (t.TransformPoint (particles [i].position)));
					} else {
						force = repel_weight.GetForce (particles [i].position);
					}
					particles [i].velocity += force * factor;
				}
				pe.particles = particles;
			}
			foreach (ParticleSystem ps in pss) {
				Transform t = ps.transform;
				ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.maxParticles];
				int num = ps.GetParticles (particles);
				for (int i = 0; i < num; i++) {
					Vector3 force;
					if (ps.simulationSpace == ParticleSystemSimulationSpace.Local) {
						force = t.InverseTransformDirection (repel_weight.GetForce (t.TransformPoint (particles [i].position)));
					} else {
						force = repel_weight.GetForce (particles [i].position);
					}
					particles [i].velocity += force * factor;
				}
				ps.SetParticles (particles, num);
			}
		}
    }

}
