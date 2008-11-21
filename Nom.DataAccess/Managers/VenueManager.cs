using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Nom.DataAccess.Objects;

namespace Nom.DataAccess.Managers
{
	public class VenueManager
	{
		public static void AddVenue(Venue venue, out int? venueId, out DateTime createdDate)
		{
			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.VenueManager.AddVenue, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@Name", venue.Name);
					if (!string.IsNullOrEmpty(venue.Name))
						cmd.Parameters.AddWithValue("@Profile", venue.Profile);
					if (!string.IsNullOrEmpty(venue.PostalCode))
						cmd.Parameters.AddWithValue("@PostalCode", venue.PostalCode);
					if (venue.PriceAverage.HasValue)
						cmd.Parameters.AddWithValue("@PriceAverage", venue.PriceAverage.Value);
					SqlParameter prmVenueId = new SqlParameter();
					prmVenueId.Direction = ParameterDirection.Output;
					prmVenueId.DbType = DbType.Int32;
					prmVenueId.ParameterName = "@VenueID";
					cmd.Parameters.Add(prmVenueId);
					SqlParameter prmCreatedDate = new SqlParameter();
					prmCreatedDate.Direction = ParameterDirection.Output;
					prmCreatedDate.DbType = DbType.DateTime;
					prmCreatedDate.ParameterName = "@CreatedDate";
					cmd.Parameters.Add(prmCreatedDate);

					conn.Open();

					cmd.ExecuteScalar();

					venueId = (int)cmd.Parameters["@VenueID"].Value;
					createdDate = (DateTime)cmd.Parameters["@CreatedDate"].Value;
				}
			}
		}

		public static void AddVenueRank(VenueRank venueRank)
		{
			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.VenueManager.AddVenueRank, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@VenueID", venueRank.VenueID);
					cmd.Parameters.AddWithValue("@UserID", venueRank.UserID);
					cmd.Parameters.AddWithValue("@Rank", venueRank.Rank);

					conn.Open();

					cmd.ExecuteNonQuery();
				}
			}
		}

		public static Venue GetVenue(int venueId)
		{
			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.VenueManager.GetVenue, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@VenueID", venueId);

					conn.Open();

					using (IDataReader reader = cmd.ExecuteReader())
					{
						return new Venue(reader);
					}
				}
			}
		}

		public static List<Venue> GetVenues()
		{
			List<Venue> venues = new List<Venue>();

			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.VenueManager.GetVenues, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					conn.Open();

					using (IDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
							venues.Add(new Venue(reader));
					}
				}
			}

			return venues;
		}

		public static void RemoveVenue(Venue venue)
		{
			if (venue.ID.HasValue)
				RemoveVenue(venue.ID.Value);
			else
				throw new Exception("Venue has not been saved and thus cannot be removed.");
		}
		public static void RemoveVenue(int venueId)
		{
			throw new Exception("Method not implemented.");
		}

		public static void UpdateVenue(Venue venue)
		{
			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.VenueManager.UpdateVenue, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@VenueID", venue.ID);
					cmd.Parameters.AddWithValue("@Name", venue.Name);
					if (!string.IsNullOrEmpty(venue.Profile))
						cmd.Parameters.AddWithValue("@Profile", venue.Profile);
					if (!string.IsNullOrEmpty(venue.PostalCode))
						cmd.Parameters.AddWithValue("@PostalCode", venue.PostalCode);
					if (venue.PriceAverage.HasValue)
						cmd.Parameters.AddWithValue("@PriceAverage", venue.PriceAverage.Value);

					conn.Open();

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
