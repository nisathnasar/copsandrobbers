using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ProtoBuf;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class SaveAndLoadScript : MonoBehaviour
    {
        public Players Teams;
        //public Player Team;
        public string File1Path;

        //GameObject playerObject;

        private void Start()
        {
            if (!ProtoBuf.Meta.RuntimeTypeModel.Default.IsDefined(typeof(Vector3)))
            {
                ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(Vector3), false).Add("x", "y", "z");
            }



            using (FileStream Stream = new FileStream(File1Path, FileMode.Create, FileAccess.Write))
            {
                Serializer.Serialize<Players>(Stream, Teams);
                Teams.setValue(10);
                byte[] b = ProtoSerialize<Players>(Teams);

                Debug.Log(b.ToString());
                Players team = ProtoDeserialize<Players>(b);
                Debug.Log(team.getValue());

                Debug.Log(team.getPlayersHit());

                Stream.Flush();
            }
        }


        public static byte[] ProtoSerialize<T>(T record) where T : class
        {
            if (null == record) return null;

            try
            {
                using (var stream = new MemoryStream())
                {
                    Serializer.Serialize(stream, record);
                    return stream.ToArray();
                }
            }
            catch
            {
                // Log error
                throw;
            }
        }

        public static T ProtoDeserialize<T>(byte[] data) where T : class
        {
            if (null == data) return null;

            try
            {
                using (var stream = new MemoryStream(data))
                {
                    return Serializer.Deserialize<T>(stream);
                }
            }
            catch
            {
                // Log error
                throw;
            }
        }



        private void Update()
        {

        }


        /*deserialize
        * MyGroup = Serializer.Deserialize<Persons>(new FileStream(File1Path, FileMode.Open, FileAccess.Read));
        */

        /*serialize
        using (FileStream Stream = new FileStream(File1Path, FileMode.Create, FileAccess.Write))
        {
            Serializer.Serialize<Players>(Stream, MyGroup);

            Stream.Flush();
        }
        */
    }
}