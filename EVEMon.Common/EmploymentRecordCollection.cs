﻿using System.Collections.Generic;
using System.Linq;
using EVEMon.Common.Collections;
using EVEMon.Common.Serialization.API;

namespace EVEMon.Common
{
    public class EmploymentRecordCollection : ReadonlyCollection<EmploymentRecord>
    {
        private readonly Character m_character;


        #region Constructor

        public EmploymentRecordCollection(Character character)
        {
            m_character = character;
        }

        #endregion


        #region Import & Export Methods

        /// <summary>
        /// Imports an enumeration of API objects.
        /// </summary>
        /// <param name="src">The enumeration of serializable objects from the API.</param>
        internal void Import(IEnumerable<SerializableEmploymentHistoryListItem> src)
        {
            Items.Clear();

            // Import the employment history from the API
            foreach (SerializableEmploymentHistoryListItem srcEmploymentRecord in src)
            {
                Items.Add(new EmploymentRecord(m_character, srcEmploymentRecord));
            }
        }

        /// <summary>
        /// Imports an enumeration of serialization objects.
        /// </summary>
        /// <param name="src">The enumeration of serializable standings from the API.</param>
        internal void Import(IEnumerable<SerializableEmploymentHistory> src)
        {
            Items.Clear();

            foreach (SerializableEmploymentHistory srcEmploymentRecord in src)
            {
                Items.Add(new EmploymentRecord(m_character, srcEmploymentRecord));
            }
        }

        /// <summary>
        /// Exports the standings to a serialization object for the settings file.
        /// </summary>
        /// <returns>List of serializable research points.</returns>
        internal IEnumerable<SerializableEmploymentHistory> Export()
        {
            return Items.Select(employmentRecord => employmentRecord.Export());
        }

        #endregion
    }
}