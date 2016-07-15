﻿using System;

namespace Abp.Runtime.Session
{
    /// <summary>
    /// Extension methods for <see cref="IAbpSession"/>.
    /// </summary>
    public static class AbpSessionExtensions
    {
        /// <summary>
        /// Gets current User's Id.
        /// Throws <see cref="AbpException"/> if <see cref="IAbpSession.UserId"/> is null.
        /// </summary>
        /// <param name="session">Session object.</param>
        /// <returns>Current User's Id.</returns>
        public static long GetUserId(this IAbpSession session)
        {
            if (!session.UserId.HasValue)
            {
                throw new AbpException("Session.UserId is null! Probably, user is not logged in.");
            }

            return session.UserId.Value;
        }

        /// <summary>
        /// Creates <see cref="UserIdentifier"/> from given session.
        /// Returns null if <see cref="IAbpSession.UserId"/> is null.
        /// </summary>
        /// <param name="session">The session.</param>
        public static UserIdentifier ToUserIdentifier(this IAbpSession session)
        {
            return session.UserId == null
                ? null
                : new UserIdentifier(session.GetUserId());
        }
    }
}